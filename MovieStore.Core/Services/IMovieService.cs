using MovieStore.Core.DTOs;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Services
{
    public interface IMovieService
    {
        Task<NewMovieDto> AddMovie(NewMovieDto newMovieResource);
        Task<Movie> UpdateMovie(UpdateMovieDto updateMovieResource);
        Task DeleteMovie(int id);
        Task<MovieDto> GetMovie(int id);
        Task<MovieWithGenresDto> GetMovieWithGenres(int id);
        Task<IEnumerable<MovieDto>> GetAllMovies();
        Task<IEnumerable<MovieDto>> GetAllMoviesWithGenres();
    }
}
