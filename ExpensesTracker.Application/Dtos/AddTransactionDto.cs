using ExpensesTracker.Core.Enums;

namespace ExpensesTracker.Application.Dtos;

public class AddTransactionDto
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TRANSACTION_TYPES Type { get; set; }
    public int CategoryId { get; set; }
}
