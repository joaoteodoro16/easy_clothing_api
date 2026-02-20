using EasyClothing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken = default);
    }
}
