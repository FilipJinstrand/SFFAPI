using Microsoft.EntityFrameworkCore;
using SFFAPI.Models;

namespace SFFAPI.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<MovieStudioModel> MovieStudios { get; set; }
        public DbSet<TriviaModel> Trivias { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=minDatabas.db");
        }
    }
}