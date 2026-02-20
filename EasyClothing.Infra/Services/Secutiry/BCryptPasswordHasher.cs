using EasyClothing.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Infra.Services.Secutiry
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha inválida.");

            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool Verify(string senha, string senhaHash)
        {
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(senhaHash))
                return false;

            return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
        }
    }
}
