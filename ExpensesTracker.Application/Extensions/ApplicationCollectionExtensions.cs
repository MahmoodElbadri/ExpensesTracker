using ExpensesTracker.Application.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExpensesTracker.Application.Extensions;

public static class ApplicationCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
