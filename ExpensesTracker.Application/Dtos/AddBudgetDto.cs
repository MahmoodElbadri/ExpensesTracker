using System.ComponentModel.DataAnnotations;

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
