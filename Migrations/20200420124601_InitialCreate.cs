using Microsoft.EntityFrameworkCore.Migrations;

namespace SFFAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieStudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanedMovies",
                columns: table => new
                {
                    LoanedMovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(nullable: false),
                    MovieStudioModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanedMovies", x => x.LoanedMovieId);
                    table.ForeignKey(
                        name: "FK_LoanedMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanedMovies_MovieStudios_MovieStudioModelId",
                        column: x => x.MovieStudioModelId,
                        principalTable: "MovieStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trivias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TriviaContent = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    MoveStudioId = table.Column<int>(nullable: false),
                    MovieStudioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trivias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trivias_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trivias_MovieStudios_MovieStudioId",
                        column: x => x.MovieStudioId,
                        principalTable: "MovieStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanedMovies_MovieId",
                table: "LoanedMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanedMovies_MovieStudioModelId",
                table: "LoanedMovies",
                column: "MovieStudioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Trivias_MovieId",
                table: "Trivias",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Trivias_MovieStudioId",
                table: "Trivias",
                column: "MovieStudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanedMovies");

            migrationBuilder.DropTable(
                name: "Trivias");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieStudios");
        }
    }
}
