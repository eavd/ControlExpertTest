using Models;
using System.Collections.Generic;
using System.Linq;

namespace DTO
{
    public static class TrackMapper
    {

        /// <summary>
        /// Method that given an entity returns its DTO.
        /// </summary>
        /// <param name="entity">Entity from which the DTO is required.</param>
        /// <returns>DTO for the entity passed by parameter.</returns>
		public static TrackDTO AsDTO(this Track entity)
        {
            TrackDTO dto = new TrackDTO
            {
                Name = entity.Name
            };

            return dto;
        }

        /// <summary>
        /// Method that gives a collection of entities returns a DTO collection
        /// </summary>
        /// <param name="entities">Collection of which DTO is required</param>
        /// <returns>Collection of DTO for the collection passed by parameter/returns>
		public static IEnumerable<TrackDTO> AsDTO(this IEnumerable<Track> entities)
        {
            return entities.Select(e => e.AsDTO()).ToArray();
        }
    }
}
