using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pedmonie.Model.Entity;
using Pedmonie.Service.Interfaces;

namespace Pedmonie.API.Controllers;
[ApiController]
[Route("[controller]")]
public class WalletTransactionController : ControllerBase
{
    private readonly IWalletService _walletService;
    private readonly ITransactionService _transaction;
    private readonly Logging _connectionStrings;

    public WalletTransactionController(IWalletService walletService, ITransactionService transaction, IOptions<Logging> connectionStrings)
    {
        _walletService = walletService;
        _transaction = transaction;
        _connectionStrings = connectionStrings.Value;
    }

    /// <summary>
    /// "This method Get wallet by walletId"
    /// </summary>
    /// <param name="walletId"></param>
    /// <returns></returns>

    [HttpGet("walletId")]
    public async Task<IActionResult> GetWalletById(Guid walletId)
    {
        var wallet = await _walletService.GetWalletByIdAsync(walletId);
        if (wallet != null)
        {
            return Ok(wallet);
        }


        return NotFound(new { message = "Wallet not found" });
    }

    //[HttpGet("get-database-url")]
    //public IActionResult GetDatabaseUrl()
    //{
    //    var databaseUrl = _configuration.GetValue<string>("DefaultConnections");
    //    if (string.IsNullOrEmpty(databaseUrl))
    //    {
    //        return NotFound("Environment variable 'DATABASE_URL' not set.");
    //    }

    //    return Ok(new { DatabaseUrl = databaseUrl });
    //}

    /// <summary>
    /// "This method Get transaction by transactionId"
    /// </summary>
    /// <param name="transactionId"></param>
    /// <returns></returns>

    [HttpGet("transactionId")]
    public async Task<IActionResult> GetTransactionsByIdAsync(Guid transactionId)
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
