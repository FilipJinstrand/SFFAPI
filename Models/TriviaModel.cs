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

        [Required]
        public MovieModel Movie { get; set; }

        [Required]
        public MovieStudioModel Studio { get; set; }
    }
}