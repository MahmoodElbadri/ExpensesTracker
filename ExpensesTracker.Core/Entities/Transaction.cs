using ExpensesTracker.Core.Enums;

namespace ExpensesTracker.Core.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TRANSACTION_TYPES Type { get; set; }
    public string Category { get; set; }
    public string UserId { get; set; }
}
