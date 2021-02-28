using MovieStore.Core.Models;
using MovieStore.Core.Repositories;
using MovieStore.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieStoreDbContext context) : base(context)
        {

        }
    }
}
