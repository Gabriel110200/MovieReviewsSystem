using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Models;

namespace MovieReview.Map
{
    public class MovieGenreMap : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(pc => new { pc.MovieId, pc.GenreId });

            builder.HasOne(m => m.Movie)
                   .WithMany(g => g.genres)
                   .HasForeignKey(m => m.MovieId);

            builder.HasOne(g => g.Genre)
                   .WithMany(m => m.Movies)
                   .HasForeignKey(g => g.GenreId);
        }
    }
}
