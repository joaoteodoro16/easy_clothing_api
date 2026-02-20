using EasyClothing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Domain.Repositories
{
    public interface  IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByToken(string token);
    }
}
