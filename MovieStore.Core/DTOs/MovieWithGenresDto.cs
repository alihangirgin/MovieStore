using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace MovieStore.Core.DTOs
{
    public class MovieWithGenresDto:MovieDto
    {
        public MovieWithGenresDto()
        {
            Genres = new Collection<GenreDto>();
        }

        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
