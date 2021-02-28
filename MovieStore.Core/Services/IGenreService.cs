using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Core.DTOs;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Services
{
    public interface IGenreService
    {
        Task<Genre> AddGenre(GenreDto newGenreResource);
        Task<GenreDto> UpdateGenre(GenreDto updateGenreResource);
        Task DeleteGenre(int id);
        Task<GenreDto> GetGenre(int id);
        Task<GenreDto> GetGenreByGenreName(string genreName);
        Task<IEnumerable<GenreDto>> GetAllGenres();
        Task<List<SelectListItem>> GetGenreList();
        Task<List<SelectListItem>> GetGenreList(List<GenreDto> selectedGenres);

    }
}
