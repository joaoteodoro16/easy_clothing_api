using EasyClothing.Domain.Entities;
using EasyClothing.Domain.Repositories;
using EasyClothing.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EasyClothingDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Email.Address == email, cancellationToken);
        }
    }
}
