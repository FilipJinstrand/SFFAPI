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

        public int MovieId { get; set; }
        public MovieModel Movie { get; set; }
        public int MoveStudioId { get; set; }
        public MovieStudioModel MovieStudio { get; set; }
    }
}