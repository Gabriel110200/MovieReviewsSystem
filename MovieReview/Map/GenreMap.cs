using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Models;

namespace MovieReview.Map
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(x => x.Description)
                    .HasColumnType("varchar(50)");



        }
    }
}
