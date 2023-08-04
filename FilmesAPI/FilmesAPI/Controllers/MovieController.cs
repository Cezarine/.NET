using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<MovieVM> Movies = new List<MovieVM>();
        private static int vID = 0;

        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieVM pMovie)
        {
            pMovie.ID = vID++;
            Movies.Add(pMovie);
            return CreatedAtAction(nameof(GetMovieFromID), new { id = pMovie.ID }, pMovie); //Esse "id" é referente ao Modelo, então tem que ser igual, ignorando letras maiusculas e minusculas
        }

        [HttpGet]
        public IEnumerable<MovieVM> GetAllMovies()
        {
            return Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieFromID(int id )
        {
            var filme =  Movies.FirstOrDefault(Movie => Movie.ID == id);
            if (filme == null)
                return NotFound();
            else
                return Ok();
        }

    }
}

