using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DTOs
{
    public class UpdateMovieDto:MovieWithGenresDto
    {
        public List<int> GenreIds { get; set; }
        public List<SelectListItem> GenreList { get; set; }
    }
}
