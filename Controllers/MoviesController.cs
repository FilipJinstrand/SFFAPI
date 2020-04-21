using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SFFAPI.Context;
using SFFAPI.Models;

namespace SFFAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MoviesController(MyDbContext context)
        {
            _context = context;
        }

        // Get: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieModel>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpGet("Etikett/{movieId}/{studioId}")]
        [Produces("application/xml")]
        public async Task<Etikett> GetEttiket(int movieId, int studioId)
        {
            var etikett = new Etikett();
            var etikettData = await etikett.CreateEtikett(_context, movieId, studioId);
            var XML = etikett.EtikettData(etikettData);
            return XML;
        }

        // Post: api/Movies
        [HttpPost]
        public async Task<ActionResult<MovieModel>> PostMovie(MovieModel movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovies", new { id = movie.Id }, movie);
        }

        // Post trivia with movie id and studio id
        [HttpPost("PostTrivia/{movieId}/{studioId}")]
        public async Task<ActionResult<TriviaModel>> PostMovieTrivia(int movieId, int studioId, TriviaModel trivia)
        {
            var movie = await _context.Movies.Where(m => m.Id == movieId).FirstOrDefaultAsync();
            var movieStudio = await _context.MovieStudios.Where(m => m.Id == studioId).FirstOrDefaultAsync();
            if (movie != null && movieStudio != null)
            {
                if (trivia.Grade > 5 || trivia.Grade < 0)
                {
                    return StatusCode(400);
                }
                movie.AddTrivia(trivia, movieStudio);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieModel movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // Delete trivia
        [HttpDelete("RemoveTrivia/{id}")]
        public async Task<ActionResult<TriviaModel>> DeleteTrivia(int id)
        {
            var trivia = await _context.Trivias.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (trivia == null)
            {
                return NotFound();
            }

            _context.Trivias.Remove(trivia);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }
    }
}
