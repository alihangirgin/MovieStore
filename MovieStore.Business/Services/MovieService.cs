using AutoMapper;
using MovieStore.Core.DTOs;
using MovieStore.Core.Models;
using MovieStore.Core.Services;
using MovieStore.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;
        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService, IGenreService genreService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _genreService = genreService;
        }

        public async Task<NewMovieDto> AddMovie(NewMovieDto newMovieResource)
        {
            try
            {
                var newMovieEntity = _mapper.Map<MovieDto, Movie>(newMovieResource);
                var user = _userService.GetUser();
                newMovieEntity.UserId = user.UserId;
                var addedMovie = await _unitOfWork.Movies.AddAsync(newMovieEntity);
                await AddMovieGenre(newMovieResource.GenreIds, addedMovie);
                await _unitOfWork.CommitAsync();
                return newMovieResource;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
            }
            return null;
        }

        public async Task AddMovieGenre(List<int> genreIds, Movie movie)
        {
            if (genreIds != null)
            {
                foreach (var item in genreIds)
                {
                    var newMovieGenre = new MovieGenre();
                    newMovieGenre.Movie = movie;
                    newMovieGenre.GenreId = item;
                    await _unitOfWork.MovieGenres.AddAsync(newMovieGenre);
                }
            }
        }

        public async Task<Movie> UpdateMovie(UpdateMovieDto updateMovieResource)
        {
            var MovieEntityToBeUpdatedResource = await GetMovie(updateMovieResource.Id);
            var MovieEntityToBeUpdated = _mapper.Map<MovieDto, Movie>(MovieEntityToBeUpdatedResource);
            var user = _userService.GetUser();
            MovieEntityToBeUpdated.UserId = user.UserId;
            MovieEntityToBeUpdated.UpdateDate = DateTime.Now;
            MovieEntityToBeUpdated.Year = updateMovieResource.Year;
            MovieEntityToBeUpdated.Plot = updateMovieResource.Plot;
            MovieEntityToBeUpdated.Title = updateMovieResource.Title;
            var updatedMovieEntity = await _unitOfWork.Movies.UpdateAsync(MovieEntityToBeUpdated);
            await UpdateMovieGenre(updateMovieResource.GenreIds, updatedMovieEntity);

            await _unitOfWork.CommitAsync();
            return updatedMovieEntity;
        }

        public async Task UpdateMovieGenre(List<int> genreIds, Movie movie)
        {
            var movieGenreList = await GetMovieGenreByMovieId(movie.Id);
            foreach (var item in movieGenreList)
            {
                foreach (var genreId in genreIds)
                {
                    if (item.Id != genreId)
                    {
                        await _unitOfWork.MovieGenres.DeleteAsync(item.Id);
                    }
                }
            }

            if (genreIds != null)
            {
                foreach (var item in genreIds)
                {
                    bool found = false;
                    foreach (var listItem in movieGenreList)
                    {
                        if(listItem.Id==item)
                        {
                            found = true;
                        }
                    }
                    if(found==false)
                    {
                        var newMovieGenre = new MovieGenre();
                        newMovieGenre.Movie = movie;
                        newMovieGenre.GenreId = item;
                        await _unitOfWork.MovieGenres.AddAsync(newMovieGenre);
                    }
                }
            }
        }

        public async Task DeleteMovie(int id)
        {
            await _unitOfWork.Movies.DeleteAsync(id);
            var movieGenres = await GetMovieGenreByMovieId(id);
            foreach (var item in movieGenres)
            {
                await _unitOfWork.MovieGenres.DeleteAsync(item.Id);
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task<MovieDto> GetMovie(int id)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == id && x.DeleteDate == null);
            var movieResource = _mapper.Map<Movie, MovieDto>(movie);
            return movieResource;
        }

        public async Task<MovieWithGenresDto> GetMovieWithGenres(int id)
        {
            var movie = await _unitOfWork.Movies.GetAsync(x => x.Id == id && x.DeleteDate == null);
            var movieGenres = await _unitOfWork.MovieGenres.GetAllAsync(x => x.MovieId == movie.Id && x.DeleteDate == null);
            var genreResources = new List<GenreDto>();
            foreach (var item in movieGenres)
            {
                var genreResource = new GenreDto();
                genreResource = await _genreService.GetGenre(item.GenreId);
                genreResources.Add(genreResource);
            }
            var movieResource = _mapper.Map<Movie, MovieDto>(movie);
            var movieWithGenresResource = _mapper.Map<MovieDto, MovieWithGenresDto>(movieResource);

            movieWithGenresResource.Genres = genreResources;
            return movieWithGenresResource;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovies()
        {
            var movieList = await _unitOfWork.Movies.GetAllAsync(x => x.DeleteDate == null);
            var movieListResource = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(movieList);
            return movieListResource;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesWithGenres()
        {
            var movieList = await _unitOfWork.Movies.GetAllAsync(x => x.DeleteDate == null);
            var MovieListResource = new List<MovieWithGenresDto>();
            foreach (var item in movieList)
            {
                var movieResource = new MovieWithGenresDto();
                movieResource = await GetMovieWithGenres(item.Id);
                MovieListResource.Add(movieResource);
            }
            return MovieListResource;
        }

        public async Task<IEnumerable<MovieGenre>> GetMovieGenreByMovieId(int id)
        {
            var movieGenreList = await _unitOfWork.MovieGenres.GetAllAsync(x => x.MovieId == id && x.DeleteDate == null);
            return movieGenreList;
        }

    }
}
