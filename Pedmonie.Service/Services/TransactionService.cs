using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedmonie.Migrationn;
using Pedmonie.Model.Entity;
using Pedmonie.Service.Interfaces;

namespace Pedmonie.Service.Services;
public class TransactionService : ITransactionService
{
    private readonly ApplicationDbContext applicationDbContext;
    public TransactionService(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    /// <summary>
    /// Get Transaction by Id
    /// </summary>
    /// <param name="transactionId"></param>
    /// <returns></returns>
    public async Task<BaseResponse<Transaction>> GetTransactionsByIdAsync(string transactionId)
    {
        var transactions = await applicationDbContext.TTransaction
            .FirstOrDefaultAsync(x => x.TransactionId == transactionId);
        if (transactions != null)
        {
            return new BaseResponse<Transaction>
            {
                IsSuccess = true,
                Message = "Transaction retrieved successfully",
                Data = transactions
            };
        }
        return new BaseResponse<Transaction>
        {
            IsSuccess = false,
            Message = "Transaction not found",
            Data = null
        };

    }
    /// <summary>
    /// Get All Transactions
    /// </summary>
    /// <returns></returns>
    public async Task<BaseResponse<List<Transaction>>> GetAllTransactionsAsync()
    {
        var transactions = await applicationDbContext.TTransaction.ToListAsync();
        if (transactions != null)
        {
            return new BaseResponse<List<Transaction>>
            {
                IsSuccess = true,
                Message = "Transactions retrieved successfully",
                Data = transactions
            };
        }
        return new BaseResponse<List<Transaction>>
        {
            IsSuccess = false,
            Message = "Transactions not found",
            Data = null
        };

    }
}

