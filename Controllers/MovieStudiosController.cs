using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFFAPI.Context;
using SFFAPI.Models;

namespace SFFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStudiosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MovieStudiosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieStudios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieStudioModel>>> GetMovieStudios()
        {
            return await _context.MovieStudios.ToListAsync();
        }

        // GET: api/MovieStudios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieStudioModel>> GetMovieStudioModel(int id)
        {
            var movieStudioModel = await _context.MovieStudios.FindAsync(id);

            if (movieStudioModel == null)
            {
                return NotFound();
            }

            return movieStudioModel;
        }

        //GET: api/MovieStudios/1/Movies
        [HttpGet("{id}/Movies")]
        public async Task<ActionResult<IEnumerable<String>>> ShowMovies(int id)
        {
            // Get the MovieStudio with LoanedMovies with Movie
            var movieStudioModel = await _context.MovieStudios.Where(m => m.Id == id)
                                                              .Include(a => a.LoanedMovies)
                                                              .ThenInclude(a => a.Movie)
                                                              .ToListAsync();

            if (movieStudioModel.FirstOrDefault() == null)
            {
                return NotFound();
            }

            // Get LoanedMovies to a list
            var loanedMovies = movieStudioModel.FirstOrDefault().LoanedMovies.ToList();

            // Select the movie from LoanedMovieList
            var movies = loanedMovies.Select(m => m.Movie).ToList();

            // Get the name for the movie
            List<string> movieNames = new List<string>();
            foreach (var m in movies)
            {
                movieNames.Add(m.Name);
            }
            return movieNames;
        }

        // PUT: api/MovieStudios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieStudioModel(int id, MovieStudioModel movieStudioModel)
        {
            if (id != movieStudioModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieStudioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieStudioModelExists(id))
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

        // POST: api/MovieStudios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieStudioModel>> PostMovieStudioModel(MovieStudioModel movieStudioModel)
        {
            _context.MovieStudios.Add(movieStudioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieStudioModel", new { id = movieStudioModel.Id }, movieStudioModel);
        }

        // DELETE: api/MovieStudios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieStudioModel>> DeleteMovieStudioModel(int id)
        {
            var movieStudioModel = await _context.MovieStudios.FindAsync(id);
            if (movieStudioModel == null)
            {
                return NotFound();
            }

            _context.MovieStudios.Remove(movieStudioModel);
            await _context.SaveChangesAsync();

            return movieStudioModel;
        }

        private bool MovieStudioModelExists(int id)
        {
            return _context.MovieStudios.Any(e => e.Id == id);
        }
    }
}
