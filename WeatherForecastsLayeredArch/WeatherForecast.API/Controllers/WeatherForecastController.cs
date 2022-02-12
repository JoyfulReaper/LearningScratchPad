using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Domain.Abstractions;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service,
            ILogger<WeatherForecastController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Domain.Models.WeatherForecast> Get()
        {
            return _service.ProccessFTempature();
        }
    }
}