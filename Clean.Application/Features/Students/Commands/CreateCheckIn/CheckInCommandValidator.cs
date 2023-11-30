using FluentValidation;

namespace Clean.Application.Features.Students.Commands.CreateCheckIn
{
    public class CheckInCommandValidator : AbstractValidator<CheckInCommand>
    {
        public CheckInCommandValidator()
        {
            RuleFor(c => c.Major).NotEmpty().WithMessage("Major is required");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(c => c.CheckInTime)
                .NotEmpty().WithMessage("Email is required")
                .Must(BeInPast).WithMessage("Check-in time must be in the past");
        }

        private bool BeInPast(DateTime time)
        {
            return time <= DateTime.Now;
        }
    }
}
