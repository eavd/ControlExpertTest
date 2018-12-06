using Models;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class WeatherService : IWeatherService
    {

        /// <summary>
        /// Services of the HttpRequestUtil class
        /// </summary>
        private static HttpRequestUtil _httpRequestUtil;

        /// <summary>
        /// Constructor of the Weather entity service
        /// </summary>
        /// <param name="httpRequestUtil">Injected services of the HttpRequestUtil class</param>
        public WeatherService(HttpRequestUtil httpRequestUtil)
        {
            _httpRequestUtil = httpRequestUtil;
        }

        /// <summary>
        /// Method that returns the weather of the given location
        /// </summary>
        /// <param name="location">Name of the city</param>
        /// <param name="latitude">Latitute of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Weather of the given location</returns>
        public async Task<Weather> GetWeather(string location, string latitude, string longitude)
        {
            string path = null;

            if (location != null)
            {
                path = string.Format(ValuesUtil.pathOpenWeatherMapLoc, location, ValuesUtil.appidOpenWeatherMap);
            }
            else if (latitude != null && longitude != null)
            {
                path = string.Format(ValuesUtil.pathOpenWeatherMapLatLon, latitude, longitude, ValuesUtil.appidOpenWeatherMap);
            }
            else
            {
                throw new NullReferenceException("There is not information to get the weather");
            }

            return await _httpRequestUtil.GetWeatherAsync(ValuesUtil.basePathOpenWeatherMap, path);            
        }

    }
}
