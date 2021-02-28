using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Seeds
{
    internal class GenreSeed : IEntityTypeConfiguration<Genre>
    {
        private readonly int[] _ids;

        public GenreSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre { Id = _ids[0], GenreName = "Action", CreateDate=DateTime.Now, UserId=1 },
            new Genre { Id = _ids[1], GenreName = "Sci-Fi", CreateDate = DateTime.Now, UserId = 1 },
            new Genre { Id = _ids[2], GenreName = "Drama", CreateDate = DateTime.Now, UserId = 1 },
            new Genre { Id = _ids[3], GenreName = "Crime", CreateDate = DateTime.Now, UserId = 1 });
        }
    }
}
