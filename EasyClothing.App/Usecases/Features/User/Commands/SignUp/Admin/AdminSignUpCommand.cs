using EasyClothing.App.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Usecases.Features.User.Commands.SignUp.Admin
{
    public record AdminSignUpCommand(string Name, string Email, string Password) : IRequest<Result<Guid>>;
}
