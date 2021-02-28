using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.Models
{
    public class Genre:Entity
    {
        public string GenreName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }

    }
}
