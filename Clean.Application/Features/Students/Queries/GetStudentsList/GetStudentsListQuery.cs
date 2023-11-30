using MediatR;

namespace Clean.Application.Features.Students.Queries.GetStudentsList
{
    public class GetStudentsListQuery : IRequest<List<StudentVM>>
    {
    }
}
