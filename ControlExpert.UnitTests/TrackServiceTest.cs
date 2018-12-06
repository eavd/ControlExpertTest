using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;
using Services.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlExpert.UnitTests
{
    [TestClass]
    public class TrackServiceTest
    {

        [TestMethod]
        public void GetWeatherByCityName()
        {
            // Arrange
            IEnumerable<Track> tracks = null;

            // Act
            Task.Run(async () =>
            {
                ITrackService _trackService = new TrackService(new HttpRequestUtil());
                tracks = await _trackService.GetRecommendationList(25);

                //Assert
                Assert.IsNotNull(tracks);

            }).GetAwaiter().GetResult();
        }

    }
}
