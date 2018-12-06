namespace Models
{
    public class Weather
    {

        /// <summary>
        /// Property Id of the Weather
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property name of the Weather
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property Cod of the Weather
        /// </summary>
        public int Cod { get; set; }

        /// <summary>
        /// Property Main of the Weather
        /// </summary>
        public virtual WeatherMain Main { get; set; }

    }
}
