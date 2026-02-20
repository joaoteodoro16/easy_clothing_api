using EasyClothing.Domain.Entities;
using EasyClothing.Domain.Repositories;
using EasyClothing.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Infra.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(EasyClothingDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken?> GetByToken(string token)
        {
            return await _dbSet.FirstOrDefaultAsync(x =>
                    x.Token == token && !x.IsRevoked);
        }
    }
}
