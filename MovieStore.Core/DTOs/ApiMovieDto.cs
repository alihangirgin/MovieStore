using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DTOs
{
    public class ApiMovieDto
    {
        public ApiMovieDto()
        {
            MovieForm = new MovieFormDto();
            MovieResult = new MovieWithGenresDto();
        }
        public MovieFormDto MovieForm { get; set; }
        public MovieWithGenresDto MovieResult { get; set; }
    }
}
