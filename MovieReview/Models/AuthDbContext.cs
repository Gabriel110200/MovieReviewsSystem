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
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);




        }

    }
}
