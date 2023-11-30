using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Queries;
using Clean.Application.Features.Students.Queries.GetStudent;
using Clean.Application.Features.Students.Queries.GetStudentCheckIns;
using Clean.Application.Features.Students.Queries.GetStudentsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<StudentVM>> Get()
        {
            var students = await _mediator.Send(new GetStudentsListQuery());
            return students;
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentVM>> GetStudentById(int id)
        {
            var student = await _mediator.Send(new GetStudentQuery { Id = id });
            return student is not null ? Ok(student) : NotFound();
        }

        [HttpGet("{id}/checkin", Name = "GetCheckInForStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CheckInVM>> GetCheckInForStudent(int id)
        {
            var student = await _mediator.Send(new GetStudentCheckInQuery { Id = id });
            return student is not null ? Ok(student) : NotFound();
        }

        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create([FromBody] CreateStudentCommand command)
        {
            var studentId = await _mediator.Send(command);
            return studentId > 0 ? Ok(studentId) : BadRequest();
        }

    }
}
