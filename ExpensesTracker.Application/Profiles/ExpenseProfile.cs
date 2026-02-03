using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Application.Profiles;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<AddTransactionDto, Transaction>();
        CreateMap<Transaction, TransactionDto>();
    }
}
