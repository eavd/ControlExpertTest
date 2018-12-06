using Models;
using Models.Enums;
using Services.Utils;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class TrackService : ITrackService
    {

        /// <summary>
        /// Services of the HttpRequestUtil class
        /// </summary>
        private readonly HttpRequestUtil _httpRequestUtil;

        /// <summary>
        /// Constructor of the Track entity service
        /// </summary>
        /// <param name="httpRequestUtil">Injected services of the HttpRequestUtil class</param>
        public TrackService(HttpRequestUtil httpRequestUtil)
        {
            _httpRequestUtil = httpRequestUtil;
        }

        /// <summary>
        /// Method that returns a list of songs with a specific genre depending on the temperature
        /// </summary>
        /// <param name="temperature">Temperture in celcius to select the genre of the tracks</param>
        /// <returns>List of Track entity</returns>
        public async Task<IEnumerable<Track>> GetRecommendationList(double temperature)
        {
            var genre = GetGenre(temperature);

            var path = string.Format(ValuesUtil.pathSpotifyAPI, genre);

            try
            {
                return await _httpRequestUtil.GetTracksAsync(ValuesUtil.basePathSpotifyAPI, path);
            }
            catch (HttpRequestException e)
            {
                if (e.Message == HttpStatusCode.Unauthorized.ToString())
                {
                    _httpRequestUtil.GetAuthorizationToken(ValuesUtil.basePathSpotifyAccount, ValuesUtil.pathSpotifyAccount);
                }
                return await GetRecommendationList(temperature);
            }
        }

        /// <summary>
        /// Method that validate what genre use by the given temperature
        /// </summary>
        /// <param name="temperture">Temperture in celcius to select the genre of the tracks</param>
        /// <returns>The genre to use</returns>
        private string GetGenre(double temperature)
        {
            if (temperature > 31)
            {
                return Genre.party.ToString();
            }
            else if (temperature >= 18 && temperature <= 31)
            {
                return Genre.classical.ToString();
            }
            else if (temperature >= 10 && temperature <= 17)
            {
                return Genre.pop.ToString();
            }
            else
            {
                return Genre.rock.ToString();
            }
        }
    }
}
