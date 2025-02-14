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
public class WalletService : IWalletService
{
    private readonly ApplicationDbContext applicationDbContext;
    public WalletService(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }
    /// <summary>
    /// Get wallet by Id
    /// </summary>
    /// <param name="walletId"></param>
    /// <returns></returns>
    public async Task<BaseResponse<Wallet>> GetWalletByIdAsync(int walletId)
    {
        var wallet = await applicationDbContext.Wallets.FindAsync(walletId);
        if (wallet != null)
        {
            return new BaseResponse<Wallet>
            {
                IsSuccess = true,
                Message = "Wallet retrieved successfully",
                Data = wallet
            };
        }
        return new BaseResponse<Wallet>
        {
            IsSuccess = false,
            Message = "Wallet not found",
            Data = null
        };



    }
}
