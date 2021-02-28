using AutoMapper;
using MovieStore.Core.DTOs;
using MovieStore.Core.Models;
using MovieStore.Core.Services;
using MovieStore.Core.UnitOfWork;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Services
{
    public class ApiService : IApiService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreService _genreService;
        public ApiService(IMapper mapper, IUserService userService, IUnitOfWork unitOfWork, IGenreService genreService)
        {
            _mapper = mapper;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _genreService = genreService;
        }
        public async Task<MovieWithGenresDto> MovieSearch(MovieFormDto movieResource)
        {

            var client = new RestClient($"http://www.omdbapi.com/?apikey=59fd7c96&t=" + movieResource.Title + "&y=" + movieResource.Year);
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var movieFoundedResource = new MovieWithGenresDto();
                var movieContentResource = JsonConvert.DeserializeObject<MovieJsonDto>(response.Content);
                if(movieContentResource.Genre !=null )
                {
                    movieFoundedResource.Title = movieContentResource.Title;
                    movieFoundedResource.Year = movieContentResource.Year;
                    movieFoundedResource.Plot = movieContentResource.Plot;
                    var genreList = new List<GenreDto>();
                    movieContentResource.Genre.Split(",").ToList().ForEach(x =>
                    {
                        var genreResource = new GenreDto()
                        {
                            GenreName = x.Trim(),
                            UserId = 1
                        };
                        genreList.Add(genreResource);
                    });
                    movieFoundedResource.Genres = genreList;
                    return movieFoundedResource;
                }
            }
            return null;
        }

        public async Task<NewMovieFromApiDto> AddMovieFromApi(NewMovieFromApiDto newMovieResource)
        {
            try
            {
                var newMovieEntity = _mapper.Map<MovieDto, Movie>(newMovieResource);
                var user = _userService.GetUser();
                newMovieEntity.UserId = user.UserId;
                var addedMovie = await _unitOfWork.Movies.AddAsync(newMovieEntity);
                await AddMovieGenreFromApi(newMovieResource.GenreNames, addedMovie);
                await _unitOfWork.CommitAsync();
                return newMovieResource;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
            }
            return null;
        }

        public async Task AddMovieGenreFromApi(List<string> genreNames, Movie movie)
        {
            if (genreNames != null)
            {
                foreach (var item in genreNames)
                {
                    var foundedGenre = await _genreService.GetGenreByGenreName(item);
                    var newMovieGenre = new MovieGenre();
                    if (foundedGenre == null)
                    {
                        var newGenreResource = new GenreDto();
                        newGenreResource.UserId = _userService.GetUser().UserId;
                        newGenreResource.GenreName = item;
                        var addedGenre= await _genreService.AddGenre(newGenreResource);

                        newMovieGenre.Movie = movie;
                        newMovieGenre.GenreId = addedGenre.Id;
                    }
                    else
                    {
                        newMovieGenre.Movie = movie;
                        newMovieGenre.GenreId = foundedGenre.Id;
                    }
                    await _unitOfWork.MovieGenres.AddAsync(newMovieGenre);
                }
            }
        }


    }
}










