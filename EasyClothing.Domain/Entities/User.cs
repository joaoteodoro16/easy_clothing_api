using EasyClothing.Domain.Common;
using EasyClothing.Domain.enums;
using EasyClothing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public Email Email { get; private set; } 
        public string Password { get; private set; }
        public Cep? Cep { get; private set; }
        public string? Street { get; private set; } = string.Empty;
        public string? City { get; private set; } = string.Empty;
        public string? State { get; private set; } = string.Empty;
        public string? Country { get; private set; } = string.Empty;
        public string? Complement { get; private set; } = string.Empty;
        public Cpf? Cpf { get; private set; }
        public CellPhone? CellPhone { get; private set; }
        public UserRole Role { get; private set; }

        public User()
        {
            
        }

        public static User CreateCustomer(
            string name,
            Email email,
            string password,
            Cpf cpf,
            CellPhone phone,
            Cep cep,
            string street,
            string city,
            string state,
            string country, string? complement)
        {
            return new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = UserRole.Customer,
                Cpf = cpf,
                CellPhone = phone,
                Cep = cep,
                Street = street,
                City = city,
                State = state,
                Country = country,
                Complement = complement
            };
        }

        public static User CreateAdmin(string name, Email email, string password)
        {
            return new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = UserRole.Admin
            };
        }

        public void SetPassword (string newPassword)
        {
            this.Password = newPassword;
        }

    }
}
