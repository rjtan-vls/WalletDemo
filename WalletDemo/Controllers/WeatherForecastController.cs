 using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace WalletDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;
    private readonly MySqlConnection _mySql;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, MySqlConnection mySql)
    {
        _logger = logger;
        _mySql = mySql;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        List<WeatherForecast> list = new List<WeatherForecast>();

        await _mySql.OpenAsync();

        using var command = new MySqlCommand("SELECT Name FROM Demo;", _mySql);
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var value = reader.GetValue(0);
            var weather = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = value.ToString()
            };

            list.Add(weather);
        }

        return list;

    }
}

