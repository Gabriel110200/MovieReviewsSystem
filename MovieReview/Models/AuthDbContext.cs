using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieReview.Models
{
    public class AuthDbContext : IdentityDbContext
    {
        public DbSet<Movie> movies { get; set; }
        public DbSet<Genre> genre { get; set; }


        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MovieGenre>().HasKey(pc => new { pc.MovieId, pc.GenreId });

            builder.Entity<MovieGenre>()
                    .HasOne(m => m.Movie)
                    .WithMany(g => g.genres)
                    .HasForeignKey(m => m.MovieId);

            builder.Entity<MovieGenre>()
                    .HasOne(g => g.Genre)
                    .WithMany(m => m.Movies)
                    .HasForeignKey(g => g.GenreId);

            builder.Entity<Movie>()
                    .HasKey(x => x.Id);

            builder.Entity<Genre>().HasKey(x => x.Id);




        }

    }
}
