using MovieStore.Core.Models;
using MovieStore.Core.Repositories;
using MovieStore.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Repositories
{
    public class MovieGenreRepository : Repository<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(MovieStoreDbContext context) : base(context)
        {

        }
    }
}
