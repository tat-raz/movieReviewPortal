using System.Data.Entity;

namespace MovieReviewPortal.Models
{
    public class MoviesDbContext : DbContext // Добавлено наследование от DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Users> Users { get; set; }

        // Конструктор вызывает базовый конструктор DbContext
        public MoviesDbContext() : base("MoviesDbConnection")
        {
        }
    }
}