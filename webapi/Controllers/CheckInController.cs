using Clean.Application.Features.Students.Commands.CreateCheckIn;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddCheckIn")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create([FromBody] CheckInCommand command)
        {
            var checkIn = await _mediator.Send(command);
            return checkIn > 0 ? Ok(checkIn) : BadRequest();
        }
    }
}