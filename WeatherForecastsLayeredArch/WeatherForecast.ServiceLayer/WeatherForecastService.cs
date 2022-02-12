using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Abstractions;

namespace WeatherForecast.ServiceLayer
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repo;

        public WeatherForecastService(IWeatherForecastRepository repo)
        {
            _repo = repo;
        }

        public List<Domain.Models.WeatherForecast> ProccessFTempature()
        {
            var forecasts = _repo.GetForeCasts();
            var processed = new List<Domain.Models.WeatherForecast>();
            foreach(var f in forecasts)
            {
                f.TemperatureF = 32 + (int)(f.TemperatureC / 0.5556);
                processed.Add(f);
            }

            return processed;
        }
    }
}
