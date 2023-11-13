using Microsoft.AspNetCore.Mvc;
using MyWeb.Commands;
using MyWeb.Result;

namespace MyWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var a = 5;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Calculate")]
        public IActionResult Culculate([FromQuery] CalculateCommand command)
        {
            return Ok(new CalculateResult
            {
                Result = command.FirstNumber + command.SecondNumber,
                Message = "Result"

            });
        }
        [HttpPost("Calculate")]
        public IActionResult Culculate2([FromQuery] CalculateCommand command)
        {
            int a = command.FirstNumber - command.ThirdNumber;
                if (a < 0)
            {
                return Ok(new CalculateResult
                {
                    Result = command.FirstNumber - command.ThirdNumber,
                    Message = "da"
                });
            }
            else
            {
                return Ok(new CalculateResult
                {
                    Result = command.FirstNumber - command.ThirdNumber,
                    Message = "Result"
                });
            }
        }
    }
}