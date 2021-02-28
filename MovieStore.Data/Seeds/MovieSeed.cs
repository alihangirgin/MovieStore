using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Seeds
{
    internal class MovieSeed : IEntityTypeConfiguration<Movie>
    {
        private readonly int[] _ids;

        public MovieSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(new Movie { Id = _ids[0], Title = "The Matrix", UserId=1, Year=1999, CreateDate=DateTime.Now, Plot= "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence." },
            new Movie { Id = _ids[1], Title = "Pulp Fiction", UserId = 1, Year = 1999, CreateDate = DateTime.Now, Plot= "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption." });
        }
    }
}
