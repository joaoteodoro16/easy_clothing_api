using EasyClothing.App.Common;
using EasyClothing.App.DTOs.Auth;
using EasyClothing.App.DTOs.User;
using EasyClothing.App.Services.Interfaces;
using EasyClothing.Domain.Entities;
using EasyClothing.Domain.Repositories;
using MediatR;

public class RefreshTokenCommandHandler
    : IRequestHandler<
        RefreshTokenCommand,
        Result<RefreshTokenResponseDto>>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUserRepository userRepository,
        ITokenService tokenService)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<Result<RefreshTokenResponseDto>> Handle(
    RefreshTokenCommand request,
    CancellationToken cancellationToken)
    {
        var refreshToken =
            await _refreshTokenRepository
            .GetByToken(request.RefreshToken);

        if (refreshToken == null ||
            refreshToken.IsExpired())
        {
            return Result<RefreshTokenResponseDto>
                .Failure(new Error(
                    ErrorCode.Unauthorized,
                    Messages.Token.RefreshTokenInvalido));
        }

        var user =
            await _userRepository
            .GetByIdAsync(refreshToken.UserId);


        refreshToken.Revoke();


        var newAccessToken =
            _tokenService.GenerateToken(user);

        var newRefreshToken =
            _tokenService.GenerateRefreshToken();


        await _refreshTokenRepository.AddAsync(
            RefreshToken.Create(
                user.Id,
                newRefreshToken));

        await _refreshTokenRepository.SaveChangesAsync();


        return Result<RefreshTokenResponseDto>
            .Success(new RefreshTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
    }
}