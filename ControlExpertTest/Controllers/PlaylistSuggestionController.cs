using Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControlExpertTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSuggestionController : ControllerBase
    {

        private static IWeatherBusiness _weatherBusiness;

        public PlaylistSuggestionController(IWeatherBusiness weatherBusiness)
        {
            _weatherBusiness = weatherBusiness;
        }

        /// <summary>
        /// Action that gets a playlist depending on the weather of the given location
        /// </summary>
        /// <param name="location">Name of the city</param>
        /// <param name="latitude">Latitute of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <returns>Playlist suggestion (only track name) according to the current temperature of the given location</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "loc")] string location,
            [FromQuery(Name = "lat")] string latitude,
            [FromQuery(Name = "lon")] string longitude)
        {
            try
            {
                return Ok(await _weatherBusiness.GetListTrackByTemperature(location, latitude, longitude));
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
            
        }

    }
}
