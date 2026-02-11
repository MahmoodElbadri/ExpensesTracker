using ExpensesTracker.Core.Entities;
using ExpensesTracker.Core.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExpensesTracker.Infrastructure.Data;

public class ExpenseDbContext:IdentityDbContext<ApplicationUser>
{

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Transaction>()
            .Property(tmp => tmp.Amount)
            .HasPrecision(18, 2);

        //making the enum taking the values as the name inside db
        modelBuilder.Entity<Transaction>()
            .Property(tmp=> tmp.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Budget>()
            .Property(tmp=>tmp.Amount)
            .HasPrecision(18,2);

        

        //modelBuilder.Entity<Transaction>()
        //    .HasData(
        //    new Transaction()
        //    {
        //        Id = 1,
        //        Description = "Salary",
        //        Amount = 5000,
        //        Type = TRANSACTION_TYPES.INCOME,
        //        Date = DateTime.Now,
        //        Category = "Salary"
        //    },
        //    new Transaction()
        //    {
        //        Id = 2,
        //        Description = "Groceries",
        //        Amount = 100,
        //        Type = TRANSACTION_TYPES.EXPENSE,
        //        Date = DateTime.Now,
        //        Category = "Groceries"
        //    },
        //    new Transaction()
        //    {
        //        Id = 3,
        //        Amount = 200,
        //        Type = TRANSACTION_TYPES.EXPENSE,
        //        Date = DateTime.Now,
        //        Category = "Entertainment",
        //        Description = "Cinema"
        //    });
    }
}
