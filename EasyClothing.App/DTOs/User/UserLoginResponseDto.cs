using EasyClothing.Domain.enums;
using EasyClothing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.DTOs.User
{
    public record UserLoginResponseDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string? Cpf { get; init; }
        public string? Phone { get; init; }
        public string? Cep { get; init; }
        public string? Street { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? Country { get; init; }
        public string? Complement { get; init; }
        public UserRole Role { get; init; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
