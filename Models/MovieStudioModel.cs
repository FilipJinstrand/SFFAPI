using System;
using System.Collections.Generic;

namespace SFFAPI.Models
{
    public class MovieStudioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<MovieModel> LoanedMovies { get; set; }

    }
}