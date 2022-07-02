using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Models;

namespace MovieReview.Map
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title)
                      .HasColumnType("varchar(70)")
                      .HasMaxLength(50);

            builder.Property(x => x.genres)
                   .IsRequired();
        }
    }
}
