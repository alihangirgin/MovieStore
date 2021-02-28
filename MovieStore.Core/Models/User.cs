using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieStore.Core.Models
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            Movies = new Collection<Movie>();
            Genres = new Collection<Genre>();
        }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

    }
}
