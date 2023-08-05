using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieDTO MovieDTO)
        {
            MovieVM movie = _mapper.Map<MovieVM>(MovieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieFromID), new { id = movie.ID }, movie); //Esse "id" é referente ao Modelo, então tem que ser igual, ignorando letras maiusculas e minusculas
        }

        [HttpGet]
        public IEnumerable<MovieVM> GetAllMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _context.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieFromID(int id )
        {
            var filme = _context.Movies.FirstOrDefault(Movie => Movie.ID == id);
            if (filme == null)
                return NotFound();
            else
                return Ok(filme);
        }

    }
}

