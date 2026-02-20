using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Services.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}
