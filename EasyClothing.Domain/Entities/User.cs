using EasyClothing.Domain.Common;
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
        public Cep Cep { get; private set; }
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public string? Complement { get; private set; } = string.Empty;
        public Cpf Cpf { get; private set; }
        public CellPhone CellPhone { get; private set; }

        public User()
        {
            
        }

        public User(string name, string email, string password, string cep, string street, string city, string state, string country, string? complement, string cpf, string cellPhone)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Complement = complement;
            this.Cpf = cpf;
            this.CellPhone = cellPhone;
        }
    }
}
