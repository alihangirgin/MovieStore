using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Core.DTOs;
using MovieStore.Core.Models;
using MovieStore.Core.Services;
using MovieStore.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Services
{
    public class GenreService:IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GenreService(IUnitOfWork unitOfWork, IMapper mapper,IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Genre> AddGenre(GenreDto newGenreResource)
        {
            var newGenreEntity = _mapper.Map<GenreDto, Genre>(newGenreResource);
            var user = _userService.GetUser();
            newGenreEntity.UserId = user.UserId;

            await _unitOfWork.Genres.AddAsync(newGenreEntity);
            await _unitOfWork.CommitAsync();
            return newGenreEntity;
        }

        public async Task<GenreDto> UpdateGenre(GenreDto updateGenreResource)
        {
            var updateGenreEntity = _mapper.Map<GenreDto, Genre>(updateGenreResource);
            var user = _userService.GetUser();
            updateGenreEntity.UserId = user.UserId;
            var updatedGenre = await _unitOfWork.Genres.UpdateAsync(updateGenreEntity);
            await _unitOfWork.CommitAsync();
            return updateGenreResource;
        }

        public async Task DeleteGenre(int id)
        {
            await _unitOfWork.Genres.DeleteAsync(id);
            var movieGenres = await GetMovieGenreByGenreId(id);
            foreach (var item in movieGenres)
            {
                await _unitOfWork.MovieGenres.DeleteAsync(item.Id);
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task<GenreDto> GetGenre(int id)
        {
            var genre = await _unitOfWork.Genres.GetAsync(x => x.Id == id && x.DeleteDate == null);
            var genreResource = _mapper.Map<Genre, GenreDto>(genre);
            return genreResource;
        }

        public async Task<GenreDto> GetGenreByGenreName(string genreName)
        {
            var genre = await _unitOfWork.Genres.GetAsync(x => x.GenreName == genreName && x.DeleteDate == null);
            var genreResource = _mapper.Map<Genre, GenreDto>(genre);
            return genreResource;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenres()
        {
            var genreList = await _unitOfWork.Genres.GetAllAsync(x => x.DeleteDate == null);
            var genreListResource = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(genreList);
            return genreListResource;
        }

        public async Task<List<SelectListItem>> GetGenreList()
        {
            var selectList = new List<SelectListItem>();
            var GenreList = await _unitOfWork.Genres.GetAllQuery(x=>x.DeleteDate==null);
            GenreList.ToList().ForEach(x =>
            {
                selectList.Add(new SelectListItem()
                {
                    Text = x.GenreName,
                    Value = x.Id.ToString()
                });

            });

            return selectList;
        }

        public async Task<List<SelectListItem>> GetGenreList(List<GenreDto> selectedGenres)
        {
            var selectList = new List<SelectListItem>();
            var GenreList = await _unitOfWork.Genres.GetAllQuery(x => true);
            GenreList.ToList().ForEach(x =>
            {
                selectList.Add(new SelectListItem()
                {
                    Selected = selectedGenres.Select(z=>z.Id).Contains(x.Id),
                    Text = x.GenreName,
                    Value = x.Id.ToString()
                });

            });

            return selectList;
        }

        public async Task<IEnumerable<MovieGenre>> GetMovieGenreByGenreId(int id)
        {
            var movieGenreList = await _unitOfWork.MovieGenres.GetAllAsync(x => x.GenreId == id && x.DeleteDate == null);
            return movieGenreList;
        }

    }
}
