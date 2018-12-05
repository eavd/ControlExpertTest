using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;

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

        // Obtener clima, deberia recibir en parametros la ciudad o la latitud y la longitud
        // Si recibo la ciudad le doy mas importancia a ella
        // Sino recibo la ciudad debo recibir la latitud y la longiud 
        // Si alguno de stos datos falta devuelvo un badrequest

        // GET api/playlistsuggestion
        [HttpGet]
        public IActionResult Get()
        {
            // return Ok(new string[] { "value1", "value2" });
            return Ok(_weatherBusiness.GetListTrackByTemperture());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
