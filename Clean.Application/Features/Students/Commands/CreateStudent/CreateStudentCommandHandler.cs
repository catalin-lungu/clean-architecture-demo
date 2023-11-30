using AutoMapper;
using Clean.Application.Contracts;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Students.Commands.CreateStudent
{
    public class CheckInCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public CheckInCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStudentCommandValidator(_studentRepository);
            var validation = await validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                throw new Exceptions.ValidationException(validation);
            }

            var student = _mapper.Map<Student>(request);
            student = await _studentRepository.AddAsync(student);
            return student.Id;
        }
    }
}
