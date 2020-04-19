using System;
using System.Linq;
using System.Collections.Generic;

namespace SFFAPI.Models
{
    public enum Category
    {
        Action,
        Horror,
        Comedy
    }
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public ICollection<TriviaModel> Trivias { get; set; } = new List<TriviaModel>();

        public void AddTrivia(TriviaModel trivia)
        {
            Trivias.Add(trivia);
        }

        public List<string> ShowTrivia()
        {
            var trivias = new List<string>();
            foreach (var t in Trivias)
            {
                trivias.Add(t.TriviaContent);
            }
            return trivias;
        }
    }
}