using AutoMapper;
using Clean.Application.Contracts;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Students.Queries.GetStudentsList
{
    public class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, List<StudentVM>>
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentsListQueryHandler(IMapper mapper, IRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentVM>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var allStudents = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentVM>>(allStudents);
        }
    }
}
