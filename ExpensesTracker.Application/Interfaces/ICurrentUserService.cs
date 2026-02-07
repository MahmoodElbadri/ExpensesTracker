namespace ExpensesTracker.Application.Interfaces;

public interface ICurrentUserService
{
    Task<string> GetUserIdAsync();
}
