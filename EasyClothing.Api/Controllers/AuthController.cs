using EasyClothing.Api.Http.Extensions;
using EasyClothing.Api.Http.Responses;
using EasyClothing.App.DTOs.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<ActionResult<ApiResponse<RefreshTokenResponseDto>>> Refresh(
        [FromBody] RefreshTokenCommand command)
    {
        var result =
            await _mediator.Send(command);

        return this.ToActionResult(result);
    }
}