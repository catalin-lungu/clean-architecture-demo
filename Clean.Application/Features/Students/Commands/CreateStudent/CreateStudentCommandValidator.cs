using Clean.Application.Contracts;
using FluentValidation;

namespace Clean.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator(IStudentRepository studentRepository)
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage($"FirstName is required");
            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("LastName is required");
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email is required")
                .MustAsync(async (email, _) =>
                {
                    return await studentRepository.IsEmailUniqueAsync(email);
                }).WithMessage("Email must be unique");
        }
    }
}
