using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Reviews.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Author", "Description", "MovieId", "Rating" },
                values: new object[] { 1, "James Fairbairn", "Amazing, must see!", 1, 5 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Author", "Description", "MovieId", "Rating" },
                values: new object[] { 2, "Zafar Khan", "Quality film!", 1, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
