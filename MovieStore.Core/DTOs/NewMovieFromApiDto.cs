using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DTOs
{
    public class NewMovieFromApiDto : MovieDto
    {
        public List<string> GenreNames { get; set; }
    }
}
