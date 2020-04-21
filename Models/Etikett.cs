using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SFFAPI.Context;

namespace SFFAPI.Models
{
    public class Etikett
    {
        public string Movie { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }


        public async Task<Etikett> CreateEtikett(MyDbContext _context, int movieId, int studioId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            var studio = await _context.MovieStudios.FindAsync(studioId);

            var etikett = new Etikett() { Movie = movie.Name, Location = studio.Location, Date = DateTime.Now };

            return etikett;
        }

        public Etikett EtikettData(Etikett etikett)
        {
            return etikett;
        }
    }
}