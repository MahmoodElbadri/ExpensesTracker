namespace ExpensesTracker.Application.Dtos;

public class BudgetStatusDto
{
    public string CategoryName { get; set; }
    public decimal Limit { get; set; }
    public decimal Spent { get; set; }
    public decimal Remaining => Limit - Spent;
    public double Percentage => (double)(Spent / Limit) * 100;
}
