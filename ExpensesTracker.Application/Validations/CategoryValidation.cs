using ExpensesTracker.Application.Dtos;
using FluentValidation;

namespace ExpensesTracker.Application.Validations;

public class CategoryValidation:AbstractValidator<AddCategoryDto>
{
    public CategoryValidation()
    {
        RuleFor(tmp => tmp.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

    }
}
