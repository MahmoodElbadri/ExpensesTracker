using ExpensesTracker.Application.Dtos;
using FluentValidation;

namespace ExpensesTracker.Application.Validations;

public class BudgetValidation : AbstractValidator<AddBudgetDto>
{
    public BudgetValidation()
    {
        RuleFor(x => x.CategoryId)
                    .NotEmpty().WithMessage("Category Id is required.");

        RuleFor(x => x.Limit)
            .NotEmpty().WithMessage("Limit is required.")
            .GreaterThan(0).WithMessage("Limit must be greater than 0.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start Date is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End Date is required.");
        
        RuleFor(tmp=>tmp.EndDate)
            .GreaterThan(tmp=>tmp.StartDate)
            .WithMessage("End Date must be greater than Start Date");
    }
}

