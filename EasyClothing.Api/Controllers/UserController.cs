using Azure;
using EasyClothing.Api.Http.Extensions;
using EasyClothing.Api.Http.Responses;
using EasyClothing.App.Usecases.Features.User.Commands.SignUp;
using EasyClothing.App.Usecases.Features.User.Commands.SignUp.Admin;
using MediatR;
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

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> CreateConsumer([FromBody] ConsumerSignUpCommand command) {
            var result = await _mediator.Send(command);
            return this.ToActionResult(result);
        }

        [HttpPost("admin")]
        public async Task<ActionResult<ApiResponse<Guid>>> CreateAdmin([FromBody] AdminSignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return this.ToActionResult(result);
        }



    }
}
