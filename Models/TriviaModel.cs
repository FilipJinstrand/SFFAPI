using System;
using System.Collections.Generic;

namespace SFFAPI.Models
{
    public class TriviaModel
    {
        public int Id { get; set; }
        public string TriviaContent { get; set; }
        public int Grade { get; set; }
        public MovieModel Movie { get; set; }
        public MovieStudioModel Studio { get; set; }
    }
}