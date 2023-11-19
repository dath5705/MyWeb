using Microsoft.AspNetCore.Mvc;

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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //[HttpGet("Calculate")]
        //public IActionResult Culculate([FromQuery] CalculateCommand command)
        //{
        //    return Ok(new CalculateResult
        //    {
        //        Equation = command.FirstNumber + " + " + command.SecondNumber + " + " + command.ThirdNumber + " = ",
        //        Result1 = command.FirstNumber + command.SecondNumber + command.ThirdNumber,
        //        Message = "Result"

        //    });
        //}
        //[HttpPost("Calculate")]
        //public IActionResult Culculate1([FromForm] CalculateCommand command)
        //{
        //    if (command.FirstNumber == 0)
        //    {
        //        return Ok(new CalculateResult
        //        {
        //            Equation = command.SecondNumber + "X + " + command.ThirdNumber,
        //            Result1 = (-command.ThirdNumber) / (command.SecondNumber),
        //            Result2 = (-command.ThirdNumber) / (command.SecondNumber),
        //            Message = "Phuong trinh co nghiem:",
        //        });
        //    }
        //    else
        //    {
        //        if (command.Delta < 0)
        //        {
        //            return Ok(new CalculateResult
        //            {
        //                Equation = command.FirstNumber + "X2 + " + command.SecondNumber + "X + " + command.ThirdNumber,
        //                Message = "Phuong trinh vo nghiem",
        //            });
        //        }
        //        else if (command.Delta == 0)
        //        {
        //            return Ok(new CalculateResult
        //            {
        //                Equation = command.FirstNumber + "X2 + " + command.SecondNumber + "X + " + command.ThirdNumber,
        //                Result1 = (-command.SecondNumber) / (2 * command.FirstNumber),
        //                Result2 = (-command.SecondNumber) / (2 * command.FirstNumber),
        //                Message = "Phuong trinh co nghiem kep:",
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new CalculateResult
        //            {
        //                Equation = command.FirstNumber + "X2 + " + command.SecondNumber + "X + " + command.ThirdNumber,
        //                Result1 = (-command.SecondNumber + Math.Sqrt(command.Delta)) / (2 * command.FirstNumber),
        //                Result2 = (-command.SecondNumber - Math.Sqrt(command.Delta)) / (2 * command.FirstNumber),
        //                Message = "Phuong trinh 2 nghiem"
        //            });

        //        }
        //    }

        //}
    }
}