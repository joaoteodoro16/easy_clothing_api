using EasyClothing.App.Common;
using EasyClothing.App.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Usecases.Features.User.Commands.Login
{
    public record UserLoginQuery(string Email, string Password) : IRequest<Result<UserLoginResponseDto>>;
}
