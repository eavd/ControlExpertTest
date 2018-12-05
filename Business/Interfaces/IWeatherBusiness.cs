using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IWeatherBusiness
    {
        IEnumerable<TrackDTO> GetListTrackByTemperture();
        
    }
}
