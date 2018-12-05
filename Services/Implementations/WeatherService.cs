using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Services
{
    public class WeatherService : IWeatherService
    {
        public IEnumerable<Track> getTest()
        {
            var track = new Track()
            {
                Id = "1",
                Name = "Test"
            };

            var tracks = new List<Track>();
            tracks.Add(track);

            return tracks;
        }
    }
}
