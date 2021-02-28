using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DTOs
{
    public class NewMovieDto:MovieDto
    {
        public List<int> GenreIds { get; set; }
        public List<SelectListItem> GenreList { get; set; }
    }
}
