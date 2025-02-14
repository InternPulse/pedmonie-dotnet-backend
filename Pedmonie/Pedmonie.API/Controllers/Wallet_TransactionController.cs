using Microsoft.AspNetCore.Mvc;
using Pedmonie.Model.Entity;
using Pedmonie.Service.Interfaces;

namespace Pedmonie.API.Controllers;
[ApiController]
[Route("[controller]")]
public class Wallet_TransactionController : ControllerBase
{
    private readonly IWalletService _walletService;
    private readonly ITransactionService _transaction;

    public Wallet_TransactionController(IWalletService walletService, ITransactionService transaction)
    {
        _walletService = walletService;
        _transaction = transaction;
    }

    /// <summary>
    /// "This method Get wallet by walletId"
    /// </summary>
    /// <param name="walletId"></param>
    /// <returns></returns>

    [HttpGet("walletId")]
    public async Task<IActionResult> GetWalletById(int walletId)
    {
        var wallet = await _walletService.GetWalletByIdAsync(walletId);
        if (wallet != null)
        {
            return Ok(wallet);
        }


        return NotFound(new { message = "Wallet not found" });
    }
    /// <summary>
    /// "This method Get transaction by transactionId"
    /// </summary>
    /// <param name="transactionId"></param>
    /// <returns></returns>

    [HttpGet("transactionId")]
    public async Task<IActionResult> GetTransactionsByIdAsync(int transactionId)
    {
        var transactions = await _transaction.GetTransactionsByIdAsync(transactionId);
        if (transactions != null)
        {
            return Ok(transactions);
        }


        return NotFound(new { message = "Transaction not found" });
    }

    /// <summary>
    /// "This method gets all transactions"
    /// </summary>
    /// <returns></returns>
    [HttpGet("transactions")]
    public async Task<IActionResult> GetAllTransactionsAsync()
    {
        var transactions = await _transaction.GetAllTransactionsAsync();
        if (transactions != null)
        {
            return Ok(transactions);
        }


        return NotFound(new { message = "Transaction not found" });
    }



}
