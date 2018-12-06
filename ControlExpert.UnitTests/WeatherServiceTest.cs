using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace ControlExpert.UnitTests
{
    [TestClass]
    public class WeatherServiceTest
    {
        [TestMethod]
        public void GetWeatherByCityName()
        {
            // Arrange
            Weather weather = null;

            // Act
            Task.Run(async () =>
            {
                IWeatherService _weatherService = new WeatherService(new HttpRequestUtil());
                weather = await _weatherService.GetWeather("cartagena,co", null, null);

                //Assert
                Assert.IsNotNull(weather);

            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void GetWeatherByCoordenates()
        {
            // Arrange
            Weather weather = null;

            // Act
            Task.Run(async () =>
            {
                IWeatherService _weatherService = new WeatherService(new HttpRequestUtil());
                weather = await _weatherService.GetWeather(null, (9.69).ToString(), (-73.26).ToString());

                //Assert
                Assert.IsNotNull(weather);

            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void GetWeatherNullReferenceExceptionTest()
        {
            // Arrange
            IWeatherService _weatherService = new WeatherService(new HttpRequestUtil());

            // Act
            Task.Run(async () =>
            {
                async Task NullReferenceExceptionTest() => await _weatherService.GetWeather(null, null, null);

                //Assert
                await Assert.ThrowsExceptionAsync<NullReferenceException>(NullReferenceExceptionTest, "There is not information to get the weather");

            }).GetAwaiter().GetResult();
        }
    }
}
