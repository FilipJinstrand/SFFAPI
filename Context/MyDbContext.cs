using Microsoft.EntityFrameworkCore;
using SFFAPI.Models;

namespace SFFAPI.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<LoanedMovie> LoanedMovies { get; set; }
        public DbSet<MovieStudioModel> MovieStudios { get; set; }
        public DbSet<TriviaModel> Trivias { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public MyDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=minDatabas.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MovieModel Setup
            modelBuilder.Entity<MovieModel>()
                        .Property(movie => movie.Name)
                        .IsRequired();

            modelBuilder.Entity<MovieModel>()
                        .Property(movie => movie.Category)
                        .IsRequired();

            // MovieStudioModel Setup
            modelBuilder.Entity<MovieStudioModel>()
                        .Property(studio => studio.Name)
                        .IsRequired();

            modelBuilder.Entity<MovieStudioModel>()
                        .Property(studio => studio.Location)
                        .IsRequired();
        }
    }
}