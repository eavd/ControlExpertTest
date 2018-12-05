using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Track
    {

        public Track()
        {
            /// <summary>
            /// Property name of the Track
            /// </summary>
            this.Albums = new HashSet<Album>();

            /// <summary>
            /// Property name of the Track
            /// </summary>
            this.Artists = new HashSet<Artist>();
        }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public virtual ICollection<Album> Albums { get; set; }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public virtual ICollection<Artist> Artists { get; set; }

    }
}
