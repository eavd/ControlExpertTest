using System.Collections.Generic;

namespace Models
{
    public class Track
    {

        /// <summary>
        /// Constructor of the Track entity
        /// </summary>
        public Track()
        {

            this.Albums = new HashSet<Album>();

            this.Artists = new HashSet<Artist>();
        }

        /// <summary>
        /// Property Id of the Track
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Property Name of the Track
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property Albums of the Track
        /// </summary>
        public virtual ICollection<Album> Albums { get; set; }

        /// <summary>
        /// Property Artists of the Track
        /// </summary>
        public virtual ICollection<Artist> Artists { get; set; }

    }
}
