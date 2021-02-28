using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MovieStore.Core.DTOs
{
    public class MovieJsonDto : MovieDto
    {
        public MovieJsonDto()
        {
        //    Genres = new Collection<string>();
        }
        public string Genre { get; set; }
    }
}
