using MediatR;

namespace Clean.Application.Features.Students.Commands.CreateCheckIn
{

    public class CheckInCommand : IRequest<int>
    {
        public string Email { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public DateTime CheckInTime { get; set; }
    }

}
