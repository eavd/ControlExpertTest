using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Utils
{
    public static class ValuesUtil
    {
        // OpenWeatherMap values
        public static readonly string basePathOpenWeatherMap = "https://api.openweathermap.org/data/2.5/weather";
        public static readonly string appidOpenWeatherMap = "57c5208f006a32ee205c633ffdc4bcb9";
        public static readonly string pathOpenWeatherMapLoc = "?q={0}&appid={1}&units=metric";
        public static readonly string pathOpenWeatherMapLatLon = "?lat={0}&lon={1}&appid={2}&units=metric";

        // Spotify values
        public static readonly string basePathSpotifyAPI = "https://api.spotify.com/v1/recommendations";
        public static readonly string basePathSpotifyAccount = "https://accounts.spotify.com/";
        public static readonly string pathSpotifyAPI = "?seed_genres={0}";
        public static readonly string pathSpotifyAccount = "api/token";
        public static readonly string SpotifyAutheticationToken = "MjcxNzk2YjI5ZmM0NDQ5MmJhZDI2ZDM3OGU2YTY2ZmQ6ZTZjNDQyZDk0MjJlNDVjMjk0MzczYmZlYjRlYzg2YmQ";
        public static readonly string SpotifyAutheticationType = "Basic";
        public static string SpotifyAutorizationToken = "Token";
        public static string SpotifyAutorizationTokenType = "Bearer";
        public static readonly Dictionary<string, string> SpotifyAutheticationBody = new Dictionary<string, string>
                {
                   { "grant_type", "client_credentials" }
                };


    }
}
