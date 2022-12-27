using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace WalletDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{


    private readonly ILogger<ProfileController> _logger;
    private readonly MySqlConnection _mySql;

    public ProfileController(ILogger<ProfileController> logger, MySqlConnection mySql)
    {
        _logger = logger;
        _mySql = mySql;
    }

    [HttpGet]
    public async Task<Profile> GetAsync()
    {
        Profile prof = new Profile();

        await _mySql.OpenAsync();

        using var command = new MySqlCommand("select * from tblProfile where profileId = 1;", _mySql);
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var profile = new Profile
            {
                ProfileId = int.Parse(reader.GetValue(reader.GetOrdinal("profileId")).ToString()),
                FirstName = reader.GetValue(reader.GetOrdinal("firstName")).ToString(),
                LastName = reader.GetValue(reader.GetOrdinal("lastName")).ToString(),
                EmailAddress = reader.GetValue(reader.GetOrdinal("emailAddress")).ToString(),
                MobileNumber = reader.GetValue(reader.GetOrdinal("mobileNumber")).ToString(),
                Address = reader.GetValue(reader.GetOrdinal("address")).ToString(),
                City = reader.GetValue(reader.GetOrdinal("city")).ToString(),
                State = reader.GetValue(reader.GetOrdinal("state")).ToString(),
                Postal = reader.GetValue(reader.GetOrdinal("postal")).ToString()

            };

            prof = profile;
        }

        return prof;

    }
}

