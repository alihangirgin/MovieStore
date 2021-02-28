using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.Models
{
    public class Movie:Entity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
