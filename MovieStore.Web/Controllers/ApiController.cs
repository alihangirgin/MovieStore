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
    public class ApiController : Controller
    {
        private readonly IApiService _apiService;
        public ApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Authorize]
        public IActionResult SearchMovie()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SearchMovie(ApiMovieDto apiMovieResource)
        {
            var foundedMovieResource= await _apiService.MovieSearch(apiMovieResource.MovieForm);
            apiMovieResource.MovieResult = foundedMovieResource;
            return View(apiMovieResource);
        }

        [Authorize]
        public async Task<IActionResult> AddMovieFromApi(string Title, int Year, string Plot, List<string> GenreList)
        {
            var newMovieResource = new NewMovieFromApiDto();
            newMovieResource.Title = Title;
            newMovieResource.Plot = Plot;
            newMovieResource.Year = Year;
            newMovieResource.GenreNames = GenreList;
            await _apiService.AddMovieFromApi(newMovieResource);

            return Redirect(Url.Action("MovieList", "Movie"));
        }
    }
}
