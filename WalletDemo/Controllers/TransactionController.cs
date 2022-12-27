using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace WalletDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{


    private readonly ILogger<TransactionController> _logger;
    private readonly MySqlConnection _mySql;

    public TransactionController(ILogger<TransactionController> logger, MySqlConnection mySql)
    {
        _logger = logger;
        _mySql = mySql;
    }

    [HttpGet]
    public async Task<IEnumerable<Transaction>> GetAsync()
    {
        List<Transaction> list = new List<Transaction>();

        await _mySql.OpenAsync();

        using var command = new MySqlCommand("SELECT BIN_TO_UUID(t.transactionId) as transactionId, t.type,t.requestAmount, t.currencyCode, t.countryCode, t.dateCreated, t.completedDate, t.vendorReference,t.vendorResponse,t.vendorFee, s.statusName,t.statusId FROM  tblTransaction t INNER JOIN tblStatus s ON t.statusId = s.statusId;", _mySql);
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            //var value = 
            var transaction = new Transaction
            {

                TransactionId = reader.GetValue(reader.GetOrdinal("transactionId")).ToString(),
                RequestAmount = Decimal.Parse(reader.GetValue(reader.GetOrdinal("requestAmount")).ToString()),
                DateCreated = DateTime.Now,
                CurrencyCode = reader.GetValue(reader.GetOrdinal("currencyCode")).ToString(),
                CountryCode = reader.GetValue(reader.GetOrdinal("countryCode")).ToString(),
                StatusId = int.Parse(reader.GetValue(reader.GetOrdinal("statusId")).ToString()),
                StatusName = reader.GetValue(reader.GetOrdinal("statusName")).ToString(),
                VendorResponse = reader.GetValue(reader.GetOrdinal("vendorResponse")).ToString(),
                VendorReference = reader.GetValue(reader.GetOrdinal("vendorReference")).ToString(),
                VendorFee = 1,
                CompletedDate = DateTime.Now,
                Type = int.Parse(reader.GetValue(reader.GetOrdinal("type")).ToString()),
            };

            list.Add(transaction);
        }

        return list;

    }
}

