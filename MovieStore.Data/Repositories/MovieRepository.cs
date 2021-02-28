using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Models;
using MovieStore.Core.Repositories;
using MovieStore.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        //private readonly DbContext _context;
        //private readonly DbSet<Movie> _dbSet;
        public MovieRepository(MovieStoreDbContext context) : base(context)
        {
            //_context = context;
            //_dbSet = context.Set<Movie>();
        }

        //public async Task<IEnumerable<Movie>> GetAllWithGenresAsync(Expression<Func<Movie, bool>> expression)
        //{
        //    return await _dbSet.Include(x => x.MovieGenres).Where(expression).Include(x=>x.Ge.ToListAsync();
        //}
    }
}
