using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        private static List<MovieVM> Movies = new List<MovieVM>();
        private static int vID = 0;

        [HttpPost]
        public void CreateMovie([FromBody] MovieVM pMovie)
        {
            pMovie.ID = vID++;
            Movies.Add(pMovie);
            Console.WriteLine(pMovie.Title);
            Console.WriteLine(pMovie.Duration);
        }

        [HttpGet]
        public IEnumerable<MovieVM> GetAllMovies()
        {
            return Movies;
        }

        [HttpGet("{id}")]
        public MovieVM? GetMovieFromID(int id )
        {
            return Movies.FirstOrDefault(Movie => Movie.ID == id);
        }

    }
}

