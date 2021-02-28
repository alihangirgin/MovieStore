using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Models;
using MovieStore.Data.Mapping;
using MovieStore.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.DataAccess
{
    public class MovieStoreDbContext : IdentityDbContext<User, Role, int>
    {

        public MovieStoreDbContext() : base()
        {

        }
        public MovieStoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GenreMap());
            builder.ApplyConfiguration(new MovieMap());
            builder.ApplyConfiguration(new MovieGenreMap());

            builder.ApplyConfiguration(new UserSeed(new int[] { 1 }));
            builder.ApplyConfiguration(new GenreSeed(new int[] { 1, 2, 3, 4 }));
            builder.ApplyConfiguration(new MovieSeed(new int[] { 1, 2 }));
            builder.ApplyConfiguration(new MovieGenreSeed(new int[] { 1, 2, 3, 4}));

        }

    }
}
