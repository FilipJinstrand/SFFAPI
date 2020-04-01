using System;
using System.Collections.Generic;

namespace SFFAPI.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        // public List<TriviaModel> Trivia { get; set; }
    }

    public enum Category
    {
        Action,
        Horror,
        Comedy
    }
}