using ElectricCompany.Application.Features.UserFeatures.Commands.Register;
using ElectricCompany.Application.Features.UserFeatures.Queries.UserQueries.GetAllUser;
using ElectricCompany.Domain.DTOS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectricCompany.Presentation.Controllers
{
    public sealed class UsersController : ApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Created("", response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUser()
        {
            GetAllUserQuery request = new();
            GetAllUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
