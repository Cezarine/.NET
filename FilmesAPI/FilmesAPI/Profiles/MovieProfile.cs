using AutoMapper;
using FilmesAPI.DTOs;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, MovieVM>();
        }
    }
}
