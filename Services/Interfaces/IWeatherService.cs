using Models;
using System.Threading.Tasks;

namespace Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Method that returns the weather of the given location
        /// </summary>
        /// <param name="location">Name of the city</param>
        /// <param name="latitude">Latitute of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Weather of the given location</returns>
        Task<Weather> GetWeather(string location, string latitude, string longitude);

    }
}
