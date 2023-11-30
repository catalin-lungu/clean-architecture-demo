using AutoMapper;
using Clean.Application.Contracts;
using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Students.Commands.CreateCheckIn
{
    public class CheckInCommandHandler : IRequestHandler<CheckInCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public CheckInCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CheckInCommand request, CancellationToken cancellationToken)
        {
            var validator = new CheckInCommandValidator();
            var validation = await validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                throw new Exceptions.ValidationException(validation);
            }

            var checkIn = _mapper.Map<CheckIn>(request);
            int checkInId = await _studentRepository.AddCheckIn(checkIn);
            return checkInId;
        }
    }
}
