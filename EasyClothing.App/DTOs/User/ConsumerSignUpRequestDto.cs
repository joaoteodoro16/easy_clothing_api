using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace EasyClothing.App.DTOs.User
{
    public record ConsumerSignUpRequestDto(string Name, string Email, string Password, string Cpf, string Phone, string Cep, string Street, string City, string State, string Country, string? Complement);
}
