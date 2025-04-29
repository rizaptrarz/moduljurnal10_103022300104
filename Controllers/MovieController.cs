using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300104.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> ListMovie = new List<Movie>
        {
            new Movie ("The Shawshank Redemption", "Frank Darabont", ["9.3"], "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie ("The Godfather", "Francis Ford Coppola", ["9.2"], "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.\r\n\r\n"),
            new Movie ("The Dark Knight", "Cristopher Nolan", ["9.0"], "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.\r\n"),

        }; 


        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return ListMovie;
        }

        [HttpGet("{index}")]

        public Movie GetMovie(int id)
        {
            return ListMovie[id];

        }
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie )
        {
            ListMovie.Add(movie);
            return Ok();
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= ListMovie.Count)
                return NotFound();
            ListMovie.RemoveAt(index);
            return Ok();
        }
    }
}
