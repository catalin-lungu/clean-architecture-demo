using AutoMapper;
using Clean.Application.Contracts;
using MediatR;

namespace Clean.Application.Features.Students.Queries.GetStudentCheckIns
{
    public class GetStudentCheckInsQueryHandler : IRequestHandler<GetStudentCheckInQuery, List<CheckInVM>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentCheckInsQueryHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        public async Task<List<CheckInVM>> Handle(GetStudentCheckInQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);
            if (student is null)
            {
                return new List<CheckInVM>();
            }
            var checkIns = await _studentRepository.GetCheckInAsync(student.Email);
            return _mapper.Map<List<CheckInVM>>(checkIns);
        }
    }
}