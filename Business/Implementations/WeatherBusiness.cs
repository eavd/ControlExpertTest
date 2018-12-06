using DTO;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class WeatherBusiness : IWeatherBusiness
    {
        /// <summary>
        /// Services of the Weather entity
        /// </summary>
        private static IWeatherService _weatherService;

        /// <summary>
        /// Services of the Track entity
        /// </summary>
        private readonly ITrackService _trackService;

        /// <summary>
        /// Constructor of the Weather entity business
        /// </summary>
        /// <param name="weatherService">Injected services of the Weather entity</param>
        /// <param name="trackService">Injected services of the Track entity</param>
        public WeatherBusiness(IWeatherService weatherService, ITrackService trackService)
        {
            _weatherService = weatherService;
            _trackService = trackService;
        }

        /// <summary>
        /// Method that returns a playlist depending on the weather of the given location
        /// </summary>
        /// <param name="location">Name of the city</param>
        /// <param name="latitude">Latitute of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Playlist suggestion (only track name) according to the current temperature of the given location</returns>
        public async Task<IEnumerable<TrackDTO>> GetListTrackByTemperature(string location, string latitude, string longitude)
        {
            Weather weather = await _weatherService.GetWeather(location, latitude, longitude);

            if (weather != null)
            {
                var tracks = await _trackService.GetRecommendationList(double.Parse(weather.Main.Temp));
                return tracks.AsDTO();
            }
            else
            {
                throw new NullReferenceException("The location or latitude and longitude that you provided where not found");
            }
        }

    }
}
