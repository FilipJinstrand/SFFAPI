using System;
using System.Linq;
using System.Collections.Generic;
using SFFAPI.Context;

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
            if (movie.Quantity > 0)
            {
                movie.Quantity--;

                LoanedMovie loaned = new LoanedMovie() { Movie = movie };
                LoanedMovies.Add(loaned);
            }
        }

        public LoanedMovie ReturnMovie(int id)
        {
            var loanedMovie = LoanedMovies.Where(m => m.MovieId == id).FirstOrDefault();
            var movie = LoanedMovies.Select(m => m.Movie).Where(m => m.Id == id).FirstOrDefault();

            if (loanedMovie != null)
            {
                LoanedMovies.Remove(loanedMovie);
                movie.Quantity++;
            }

            return loanedMovie;
        }
    }
}