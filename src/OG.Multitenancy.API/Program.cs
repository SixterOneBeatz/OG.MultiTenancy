using Microsoft.EntityFrameworkCore;
using OG.Multitenancy.API.Data;
using OG.Multitenancy.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MasterDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrganizationAdmin")));
builder.Services.AddDbContext<OrganizationDbContext>();
builder.Services.AddTransient<IOrganizationDbCreator, OrganizationDbCreator>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ITenantService, TenantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
