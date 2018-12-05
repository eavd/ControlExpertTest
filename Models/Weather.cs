using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Weather
    {

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public int Cod { get; set; }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public virtual WeatherMain Main { get; set; }

    }
}
