using EasyClothing.App.Common;
using EasyClothing.App.DTOs.Auth;
using EasyClothing.App.DTOs.User;
using MediatR;

public record RefreshTokenCommand(string RefreshToken)
    : IRequest<Result<RefreshTokenResponseDto>>;
