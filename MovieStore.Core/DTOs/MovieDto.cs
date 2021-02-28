using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
    }
}
