using Microsoft.EntityFrameworkCore;
using SFFAPI.Models;
namespace SFFAPI.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<MovieModel> MovieItems { get; set; }
    }
}