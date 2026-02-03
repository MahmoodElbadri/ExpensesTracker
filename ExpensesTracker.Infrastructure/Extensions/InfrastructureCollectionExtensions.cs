using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Infrastructure.Data;
using ExpensesTracker.Infrastructure.Repositories;
using ExpensesTracker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesTracker.Infrastructure.Extensions;

public static class InfrastructureCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ExpenseDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITransactionService, TransactionServices>();
    }
}
