﻿namespace OG.Multitenancy.Application.Common.UnitOfWork
{
    public interface IBaseUoW
    {
        Task<int> Commit();
    }
}
