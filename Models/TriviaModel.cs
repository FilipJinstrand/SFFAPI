using System;
using System.Collections.Generic;

namespace SFFAPI.Models
{
    public class TriviaModel
    {
        public string TriviaContent { get; set; }
        public MovieModel Movie { get; set; }
        public MovieStudioModel Studio { get; set; }
    }
}