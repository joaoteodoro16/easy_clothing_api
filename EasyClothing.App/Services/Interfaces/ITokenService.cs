using EasyClothing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
 

namespace EasyClothing.App.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
    }
}
