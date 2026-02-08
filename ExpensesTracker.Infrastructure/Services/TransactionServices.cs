using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Exceptions;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Core.Entities;
using ExpensesTracker.Core.Enums;

namespace ExpensesTracker.Infrastructure.Services;

public class TransactionServices(IMapper mapper, IUnitOfWork uow, ICurrentUserService currentUser) : ITransactionService
{
    public async Task<bool> CreateTransactionAsync(AddTransactionDto dto)
    {
        var user = await currentUser.GetUserIdAsync();
        var transaction = mapper.Map<AddTransactionDto, Transaction>(dto);
        transaction.UserId = user;
        await uow.Transactions.AddAsync(transaction);
        return await uow.CompleteAsync() > 0;
    }

    public async Task<bool> DeleteTransactionAsync(int transactionId)
    {
        var user = await currentUser.GetUserIdAsync();
        var transaction = await uow.Transactions.FindAsync(tmp => tmp.Id == transactionId && tmp.UserId == user);
        var transactionToDelete = transaction.FirstOrDefault();
        if (transactionToDelete != null)
        {
            uow.Transactions.Delete(transactionToDelete);

            return await uow.CompleteAsync() > 0;
        }
        throw new NotFoundException(nameof(Transaction), transactionId.ToString());
    }

    public async Task<List<TransactionDto>> GetAllTransactionsAsync()
    {
        var user = await currentUser.GetUserIdAsync();
        var transactions = await uow.Transactions.FindAsync(tmp => tmp.UserId == user);
        var dtos = mapper.Map<List<TransactionDto>>(transactions);
        return dtos;
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        var user = await currentUser.GetUserIdAsync();
        var transactions = await uow.Transactions.FindAsync(tmp => tmp.UserId == user);
        //getting dashboard items which are total income and total expense and balance based on amound and type

        var TotalExpense = transactions.Where(tmp => tmp.Type == TRANSACTION_TYPES.EXPENSE).Sum(tmp => tmp.Amount);
        var TotalIncome = transactions.Where(tmp => tmp.Type == TRANSACTION_TYPES.INCOME).Sum(tmp => tmp.Amount);
        var Balance = TotalIncome - TotalExpense;

        var dashboard = new DashboardDto()
        {
            TotalExpense = TotalExpense,
            TotalIncome = TotalIncome,
            Balance = Balance
        };

        return dashboard;
    }

    public async Task<TransactionDto?> GetTransactionByIdAsync(int transactionId)
    {
        var user = await currentUser.GetUserIdAsync();
        var transaction = await uow.Transactions.FindAsync(tmp => tmp.Id == transactionId && tmp.UserId == user);
        var dto = mapper.Map<TransactionDto>(transaction.FirstOrDefault());
        return dto;
    }

    public async Task UpdateTransactionAsync(AddTransactionDto transactionDto, int id)
    {
        var userId = await currentUser.GetUserIdAsync();

        // 1. هات الترانزاكشن (كدة بقت Tracked)
        var existingTransaction = await uow.Transactions.FindAsync(t => t.Id == id && t.UserId == userId);
        var result = existingTransaction.FirstOrDefault();

        if (existingTransaction == null)
        {
            throw new NotFoundException(nameof(Transaction), id.ToString());
        }

        // 2. التظبيطة هنا:
        // قول للمابر يحدث الـ existingTransaction بالبيانات اللي في الـ DTO
        // بدل ما يكريت واحد جديد
        mapper.Map(transactionDto, result);

        // 3. مش محتاج تعمل uow.Transactions.Update()
        // لأن الـ existingTransaction أصلاً Tracked والـ Map غيرت في قيمه
        // الـ EF Core ذكي كفاية انه يعرف التغيير لوحده

        await uow.CompleteAsync();
    }
}

/*
 * An error occurred: The instance of entity type 'Transaction' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.
 * */