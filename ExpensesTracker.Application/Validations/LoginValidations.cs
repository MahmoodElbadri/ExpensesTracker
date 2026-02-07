using FluentValidation;
using ExpensesTracker.Application.Dtos;

namespace ExpensesTracker.Application.Validations;

public class LoginValidations : AbstractValidator<LoginDto>
{
    public LoginValidations()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}


