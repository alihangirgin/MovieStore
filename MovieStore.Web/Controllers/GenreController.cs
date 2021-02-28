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
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [Authorize]
        public  IActionResult NewGenre()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewGenre(GenreDto newGenreResource)
        {
            await _genreService.AddGenre(newGenreResource);
            return RedirectToAction("GenreList");
        }

        [Authorize]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenre(id);
            return RedirectToAction("GenreList");
        }

        [Authorize]
        public async Task<IActionResult> UpdateGenre(int id)
        {
            var genre = await _genreService.GetGenre(id);
            return View(genre);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateGenre(GenreDto updateGenreResource)
        {
            await _genreService.UpdateGenre(updateGenreResource);
            return RedirectToAction("GenreList");
        }

        [Authorize]
        public async Task<IActionResult> GenreList()
        {
            var genreListResource = await _genreService.GetAllGenres();
            return View(genreListResource);
        }
    }
}
