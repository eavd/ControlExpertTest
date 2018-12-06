using Models;
using System.Collections.Generic;

namespace DTO
{
    public class TrackSpotifyDTO
    {

        public TrackSpotifyDTO()
        {
            
            /// <summary>
            /// Property name of the Track
            /// </summary>
            this.Tracks = new HashSet<Track>();

        }

        /// <summary>
        /// Property name of the Track
        /// </summary>
        public virtual ICollection<Track> Tracks { get; set; }

    }
}
