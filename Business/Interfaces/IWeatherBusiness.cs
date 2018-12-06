using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IWeatherBusiness
    {

        /// <summary>
        /// Method that returns a playlist depending on the weather of the given location
        /// </summary>
        /// <param name="location">Name of the city</param>
        /// <param name="latitude">Latitute of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Playlist suggestion (only track name) according to the current temperature of the given location</returns>
        Task<IEnumerable<TrackDTO>> GetListTrackByTemperature(string location, string latitude, string longitude);
        
    }
}
