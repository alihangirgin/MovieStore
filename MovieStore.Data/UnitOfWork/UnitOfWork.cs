using MovieStore.Core.Repositories;
using MovieStore.Core.UnitOfWork;
using MovieStore.Data.DataAccess;
using MovieStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieStoreDbContext _context;

        private MovieRepository _movieRepository;
        private GenreRepository _genreRepository;
        private MovieGenreRepository _movieGenreRepository;

        public UnitOfWork(MovieStoreDbContext context)
        {
            _context = context;
        }

        public IMovieRepository Movies => _movieRepository = _movieRepository ?? new MovieRepository(_context);
        public IGenreRepository Genres => _genreRepository = _genreRepository ?? new GenreRepository(_context);
        public IMovieGenreRepository MovieGenres => _movieGenreRepository = _movieGenreRepository ?? new MovieGenreRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
