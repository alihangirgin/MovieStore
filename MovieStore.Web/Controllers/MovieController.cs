using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.DTOs;
using MovieStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        IMapper _mapper;
        public MovieController(IMovieService movieService, IGenreService genreService, IMapper mapper)
        {
            _movieService = movieService;
            _genreService = genreService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> NewMovie()
        {
            var newMovieResource = new NewMovieDto();
            newMovieResource.GenreList=  await _genreService.GetGenreList();

            return View(newMovieResource);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewMovie(NewMovieDto newMovieResource)
        {
            await _movieService.AddMovie(newMovieResource);
            return RedirectToAction("MovieList");
        }

        [Authorize]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovie(id);
            return RedirectToAction("MovieList");
        }

        [Authorize]
        public async Task<IActionResult> UpdateMovie(int id)
        {
            var movieWithGenresResource = await _movieService.GetMovieWithGenres(id);
            var updateMovieResource= _mapper.Map<MovieWithGenresDto, UpdateMovieDto>(movieWithGenresResource);
            updateMovieResource.GenreList = await _genreService.GetGenreList(movieWithGenresResource.Genres.ToList());
            return View(updateMovieResource);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieResource)
        {
            await _movieService.UpdateMovie(updateMovieResource);
            return RedirectToAction("MovieList");
        }

        [Authorize]
        public async Task<IActionResult> MovieList()
        {
            var movieListWithGenresResource = await _movieService.GetAllMoviesWithGenres();
            return View(movieListWithGenresResource);
        }


    }
}
