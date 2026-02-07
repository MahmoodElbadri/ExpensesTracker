using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpensesTracker.Infrastructure.Services;

public class AuthService(UserManager<ApplicationUser> _userManager, IConfiguration _configuration) : IAuthService
{
    public async Task<AuthResponseDto> LoginUserAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new Exception("Email or password is invalid");
        }
        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!result)
        {
            throw new Exception("Email or password is invalid");
        }
        return new AuthResponseDto
        {
            Email = user.Email,
            Fullname = user.Fullname,
            Token = CreateToken(user)
        };
    }

    public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto dto)
    {
        var user = new ApplicationUser
        {
            Email = dto.Email,
            Fullname = dto.Fullname,
            UserName = dto.Email
        };
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();
            throw new Exception(string.Join(" ", errors));
        }
        return new AuthResponseDto
        {
            Email = user.Email,
            Fullname = user.Fullname,
            Token = CreateToken(user)
        };
    }
    private string CreateToken(ApplicationUser user)
    {
        // A. Claims: البيانات اللي جوه التوكن (البطاقة الشخصية)
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Fullname),
            new Claim(ClaimTypes.NameIdentifier, user.Id), // مهم جداً عشان نعرف مين اليوزر بعدين
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // ID للتوكن نفسه
        };

        // B. Key: المفتاح السري اللي في appsettings
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // C. Token Setup: إعدادات التوكن (مين المصدر، مين المستلم، مدته قد ايه)
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:DurationInMinutes"])),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = creds
        };

        // D. Build: تصنيع التوكن النهائي
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
