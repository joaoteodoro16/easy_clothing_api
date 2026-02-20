using Azure;
using EasyClothing.Api.Http.Extensions;
using EasyClothing.Api.Http.Responses;
using EasyClothing.App.DTOs.User;
using EasyClothing.App.Usecases.Features.User.Commands.Login;
using EasyClothing.App.Usecases.Features.User.Commands.SignUp;
using EasyClothing.App.Usecases.Features.User.Commands.SignUp.Admin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyClothing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        //[Authorize(Roles = "Admin")] Pra quando eu for inserir roles nos tokens
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> CreateConsumer([FromBody] ConsumerSignUpCommand command) {
            var result = await _mediator.Send(command);
            return this.ToActionResult(result);
        }

        [AllowAnonymous]
        [HttpPost("admin")]
        public async Task<ActionResult<ApiResponse<Guid>>> CreateAdmin([FromBody] AdminSignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return this.ToActionResult(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<UserLoginResponseDto>>> Login([FromBody] UserLoginQuery query)
        {
            var result = await _mediator.Send(query);
            return this.ToActionResult(result);
        }
    }
}
