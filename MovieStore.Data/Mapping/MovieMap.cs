using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Mapping
{
    public class MovieMap : Mapping<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Plot).HasMaxLength(500);
            builder.Property(x => x.Year).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
