using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public int UserId { get; set; }
    }
}
