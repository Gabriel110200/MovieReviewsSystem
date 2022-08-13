using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieReview.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Map
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                      .HasColumnType("varchar(70)")
                      .HasMaxLength(50)
                      .IsRequired();

            builder.Property(x => x.ReleaseDate)
                   .HasColumnType("date")
                   .IsRequired();



        }
    }
}
