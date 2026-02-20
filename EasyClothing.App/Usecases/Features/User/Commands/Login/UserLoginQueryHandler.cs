using AutoMapper;
using EasyClothing.App.Common;
using EasyClothing.App.DTOs.User;
using EasyClothing.App.Services.Interfaces;
using EasyClothing.Domain.Entities;
using EasyClothing.Domain.Repositories;
using MediatR;

namespace EasyClothing.App.Usecases.Features.User.Commands.Login
{
    public class UserLoginQueryHandler
        : IRequestHandler<UserLoginQuery, Result<UserLoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public UserLoginQueryHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IMapper mapper,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<Result<UserLoginResponseDto>> Handle(
            UserLoginQuery request,
            CancellationToken cancellationToken)
        {
            var userExist =
                await _userRepository.GetUserByEmail(request.Email);

            if (userExist == null)
                return Result<UserLoginResponseDto>.Failure(
                    new Error(
                        ErrorCode.Unauthorized,
                        Messages.User.EmailOuSenhaInvalidos));


            var passwordValid =
                _passwordHasher.Verify(
                    request.Password,
                    userExist.Password);

            if (!passwordValid)
                return Result<UserLoginResponseDto>.Failure(
                    new Error(
                        ErrorCode.Unauthorized,
                        Messages.User.EmailOuSenhaInvalidos));

            var response =
                _mapper.Map<UserLoginResponseDto>(userExist);

            var accessToken =
                _tokenService.GenerateToken(userExist);

            var refreshToken =
                _tokenService.GenerateRefreshToken();
            var refreshTokenEntity =
                RefreshToken.Create(
                    userExist.Id,
                    refreshToken
                    );

            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            response.AccessToken = accessToken;
            response.RefreshToken = refreshToken;

            return Result<UserLoginResponseDto>.Success(
                response,
                Messages.User.UsuarioAutenticado);
        }
    }
}