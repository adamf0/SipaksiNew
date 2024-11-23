﻿namespace SipaksiNew.Modules.User.Application.Abstractions.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
