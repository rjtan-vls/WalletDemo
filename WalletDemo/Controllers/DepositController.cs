using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace WalletDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class DepositController : ControllerBase
{


    private readonly ILogger<DepositController> _logger;
    private readonly MySqlConnection _mySql;

    public DepositController(ILogger<DepositController> logger, MySqlConnection mySql)
    {
        _logger = logger;
        _mySql = mySql;
    }

    //[HttpPost]
    //public async Task<string> PostAsync()
    //{
       

    //    await _mySql.OpenAsync();

    //    using var command = new MySqlCommand("SELECT Balance FROM tblWalletBalance;", _mySql);
    //    decimal balance = 0;


    //    var decBalance = decimal.TryParse(command.ExecuteScalar().ToString(), out balance);
    //    var walletBalance = new WalletBalance()
    //    {
    //        Balance = balance
    //    };


    //    //using var reader = await command.ExecuteReaderAsync();
    //    //while (await reader.ReadAsync())
    //    //{
    //    //    //var value = 
    //    //    var transaction = new Transaction
    //    //    {

    //    //        TransactionId = reader.GetValue(reader.GetOrdinal("transactionId")).ToString(),
    //    //        RequestAmount = Decimal.Parse(reader.GetValue(reader.GetOrdinal("requestAmount")).ToString()),
    //    //        DateCreated = DateTime.Now,
    //    //        CurrencyCode = reader.GetValue(reader.GetOrdinal("currencyCode")).ToString(),
    //    //        CountryCode = reader.GetValue(reader.GetOrdinal("countryCode")).ToString(),
    //    //        StatusId = int.Parse(reader.GetValue(reader.GetOrdinal("statusId")).ToString()),
    //    //        StatusName = reader.GetValue(reader.GetOrdinal("statusName")).ToString(),
    //    //        VendorResponse = reader.GetValue(reader.GetOrdinal("vendorResponse")).ToString(),
    //    //        VendorReference = reader.GetValue(reader.GetOrdinal("vendorReference")).ToString(),
    //    //        VendorFee = 1,
    //    //        CompletedDate = DateTime.Now
    //    //    };

    //    //    list.Add(transaction);
    //    //}

    //    return walletBalance;

    //}
}

