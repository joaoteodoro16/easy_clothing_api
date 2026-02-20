using EasyClothing.App.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Usecases.Features.User.Commands.SignUp
{
    public record ConsumerSignUpCommand(ConsumerSignUpRequestDto consumer) : IRequest<Guid>;
}

