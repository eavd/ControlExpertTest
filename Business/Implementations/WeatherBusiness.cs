using DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class WeatherBusiness : IWeatherBusiness
    {

        private static IWeatherService _weatherService;

        public WeatherBusiness(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IEnumerable<TrackDTO> GetListTrackByTemperture()
        {
            return _weatherService.getTest().AsDTO();
        }
    }
}
