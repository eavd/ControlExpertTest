using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Services.Utils
{
    public class HttpRequestUtil
    {
        /// <summary>
        /// Asynchronous method that get the Weather
        /// </summary>
        /// <param name="basePath">The base path of the API</param>
        /// <param name="path">The path of the API</param>
        /// <returns></returns>
        public async Task<Weather> GetWeatherAsync(string basePath, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(basePath);
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Weather>();
                }
                return null;
            }
        }

        /// <summary>
        /// Asynchronous method that get the list of tracks
        /// </summary>
        /// <param name="basePath">The base path of the API</param>
        /// <param name="path">The path of the API</param>
        /// <returns>List of tracks filtred by genre</returns>
        public async Task<IEnumerable<Track>> GetTracksAsync(string basePath, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(basePath);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ValuesUtil.SpotifyAutorizationTokenType, ValuesUtil.SpotifyAutorizationToken);

                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var objectResponse = await response.Content.ReadAsAsync<TrackSpotifyDTO>();

                    return objectResponse.Tracks;
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            // TODO: implementar solucion a un badrequest
                            break;

                        case HttpStatusCode.Unauthorized:
                            throw new HttpRequestException(HttpStatusCode.Unauthorized.ToString());
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Asynchronous method that authorizes the app in the Spotify API
        /// </summary>
        /// <param name="basePath">The base path of the API</param>
        /// <param name="path">The path of the API</param>
        public async void GetAuthorizationToken(string basePath, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(basePath);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ValuesUtil.SpotifyAutheticationType, ValuesUtil.SpotifyAutheticationToken);

                var content = new FormUrlEncodedContent(ValuesUtil.SpotifyAutheticationBody);

                HttpResponseMessage response = await client.PostAsync(path, content);
                if (response.IsSuccessStatusCode)
                {
                    var spotifyToken = await response.Content.ReadAsAsync<SpotifyTokenDTO>();
                    ValuesUtil.SpotifyAutorizationToken = spotifyToken.Access_token;
                    ValuesUtil.SpotifyAutorizationTokenType = spotifyToken.Token_type;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
