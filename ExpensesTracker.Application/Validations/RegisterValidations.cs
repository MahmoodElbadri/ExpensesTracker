using ExpensesTracker.Application.Dtos;
using FluentValidation;

namespace ExpensesTracker.Application.Validations;

public class RegisterValidations : AbstractValidator<RegisterDto>
{
    public RegisterValidations()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        RuleFor(tmp=>tmp.Fullname)
            .NotEmpty().WithMessage("Fullname is required.");

    }
}