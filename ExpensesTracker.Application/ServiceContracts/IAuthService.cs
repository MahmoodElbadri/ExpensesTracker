using ExpensesTracker.Application.Dtos;

namespace ExpensesTracker.Application.ServiceContracts;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterUserAsync(RegisterDto dto);
    Task<AuthResponseDto> LoginUserAsync(LoginDto dto);
}
