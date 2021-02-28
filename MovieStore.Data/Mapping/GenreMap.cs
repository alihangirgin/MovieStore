using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Mapping
{
    public class GenreMap : Mapping<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.GenreName).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Genres)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
