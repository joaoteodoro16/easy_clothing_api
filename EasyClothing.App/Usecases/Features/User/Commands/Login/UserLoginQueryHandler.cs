using AutoMapper;
using EasyClothing.App.Common;
using EasyClothing.App.DTOs.User;
using EasyClothing.App.Services.Interfaces;
using EasyClothing.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Usecases.Features.User.Commands.Login
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, Result<UserLoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        public UserLoginQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._passwordHasher = passwordHasher;
            this._mapper = mapper;
        }

        public async Task<Result<UserLoginResponseDto>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetUserByEmail(request.Email);
            if(userExist == null) return Result<UserLoginResponseDto>.Failure(new Error(ErrorCode.Unauthorized, Messages.User.EmailOuSenhaInvalidos));

            var passwordValid = _passwordHasher.Verify(request.Password, userExist.Password);

            if (!passwordValid) return Result<UserLoginResponseDto>.Failure(new Error(ErrorCode.Unauthorized, Messages.User.EmailOuSenhaInvalidos));

            var response = _mapper.Map<UserLoginResponseDto>(userExist);

            return Result<UserLoginResponseDto>.Success(response, Messages.User.UsuarioAutenticado);
        }
    }
}
