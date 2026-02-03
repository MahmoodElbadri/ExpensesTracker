using Microsoft.AspNetCore.Identity;

namespace ExpensesTracker.Core.Entities;

public class ApplicationUser: IdentityUser
{
    public string Fullname { get; set; }
}
