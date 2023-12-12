using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using OG.Multitenancy.Application.Common.DTOs;
using OG.Multitenancy.Application.Common.Services;
using OG.Multitenancy.Application.Common.UnitOfWork;
using OG.Multitenancy.Domain;
using System.Xml.Linq;
using System;
using static OG.Multitenancy.Application.Common.Constants.SettingsConsts;

namespace OG.Multitenancy.Application.Features.Organization.Commands
{
    public class CreateOrganizationCommand(OrganizationDTO organization) : IRequest<int>
    {
        public OrganizationDTO Organization { get; set; } = organization;
    }

    public class CreateOrganizationCommandHandler(IMasterUoW masterUnitOfWork,
        IDbCreatorService dbCreatorService,
        IConfiguration configuration,
        IMapper mapper) : IRequestHandler<CreateOrganizationCommand, int>
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IDbCreatorService _dbCreatorService = dbCreatorService;
        private readonly IMasterUoW _masterUnitOfWork = masterUnitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            int result = 0;
            bool exists = await this._masterUnitOfWork.OrganinzationRepository.Exist(request.Organization.Name);

            if (!exists)
            {
                string connectionString = string.Format(this._configuration.GetConnectionString(TEMPLATE_CS_KEY), request.Organization.Name);

                var toCreate = this._mapper.Map<OrganizationDom>(request.Organization);
                toCreate.Active = true;
                toCreate.ConnectionString = connectionString;

                OrganizationDom created = await this._masterUnitOfWork.OrganinzationRepository.Create(toCreate);

                await _masterUnitOfWork.Commit();

                if (created is not null)
                {
                    await this._dbCreatorService.Create(created);
                    result = created.Id;
                }
            }

            return result;
        }
    }
}
