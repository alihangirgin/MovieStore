using MovieStore.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Services
{
    public interface IApiService
    {
        Task<MovieWithGenresDto> MovieSearch(MovieFormDto movieResource);
        Task<NewMovieFromApiDto> AddMovieFromApi(NewMovieFromApiDto newMovieResource);
    }
}
