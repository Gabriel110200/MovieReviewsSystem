using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.Migrations
{
    public partial class bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genre_GenreId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "movies");

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId",
                table: "movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genre_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
