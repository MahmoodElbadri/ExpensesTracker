using ExpensesTracker.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ExpensesTracker.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<string> GetUserIdAsync()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        return user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }
}
