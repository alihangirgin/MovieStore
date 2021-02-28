using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Seeds
{
    internal class MovieGenreSeed : IEntityTypeConfiguration<MovieGenre>
    {
        private readonly int[] _ids;

        public MovieGenreSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasData(new MovieGenre { Id = _ids[0],  MovieId =1, GenreId=1, CreateDate = DateTime.Now},
            new MovieGenre { Id = _ids[1], MovieId = 1, GenreId = 2, CreateDate = DateTime.Now },
            new MovieGenre { Id = _ids[2], MovieId = 2, GenreId = 3, CreateDate = DateTime.Now },
            new MovieGenre { Id = _ids[3], MovieId = 2, GenreId = 4, CreateDate = DateTime.Now });
        }
    }
}
