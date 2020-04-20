using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SFFAPI.Models
{
    public class TriviaModel
    {
        public int Id { get; set; }
        public string TriviaContent { get; set; }
        public int Grade { get; set; }

        public MovieModel Movie { get; set; }
        public MovieStudioModel MovieStudio { get; set; }
    }
}