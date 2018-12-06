using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ITrackService
    {
        /// <summary>
        /// Method that returns a list of songs with a specific genre depending on the temperature
        /// </summary>
        /// <param name="temperature">Temperture in celcius to select the genre of the tracks</param>
        /// <returns>List of Track entity</returns>
        Task<IEnumerable<Track>> GetRecommendationList(double temperature);

    }
}
