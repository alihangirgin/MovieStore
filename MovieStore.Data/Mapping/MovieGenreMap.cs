using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Mapping
{
    public class MovieGenreMap: Mapping<MovieGenre>
    {
        public override void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Movie)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.MovieId)
                .IsRequired();

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.GenreId)
                .IsRequired();
        }

    }
}
