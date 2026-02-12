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
    }
}

/*
* using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Application.Dtos;

public class AddBudgetDto
{
[Required]
public int CategoryId { get; set; }

[Required]
[Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
public decimal Limit { get; set; } // المبلغ المسموح بيه

[Required]
public DateTime StartDate { get; set; }

[Required]
public DateTime EndDate { get; set; }
}
*/