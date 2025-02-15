﻿using Entities;

namespace Data.Contracts
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User?> GetByMobileAndPass(string mobile, string password, CancellationToken cancellationToken);
        Task AddAsync(User user, string password, CancellationToken cancellationToken);
        Task UpdateSecurityStampAsync(User user, CancellationToken cancellationToken);
        Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken);
    }
}