namespace SFFAPI.Models
{
    public class LoanedMovie
    {
        public int LoanedMovieId { get; set; }
        public int MovieId { get; set; }
        public MovieModel Movie { get; set; }

    }
}