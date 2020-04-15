using System;
using System.Linq;
using System.Collections.Generic;

namespace SFFAPI.Models
{
    public class MovieStudioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<LoanedMovie> LoanedMovies { get; set; } = new List<LoanedMovie>();

        public void AddMovie(MovieModel movie)
        {
            movie.Quantity--;
            LoanedMovie loaned = new LoanedMovie() { Movie = movie };
            LoanedMovies.Add(loaned);
        }

        public void ReturnMovie(int id)
        {
            // var movieId = LoanedMovies.Select(m => m.MovieId).Where(m => m.);
            // LoanedMovies.Remove();
        }
    }
}