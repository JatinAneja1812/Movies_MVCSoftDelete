using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    NationalityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    DirectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_People_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.PersonId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 2, null, new DateTime(2009, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Trek" });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "Title" },
                values: new object[,]
                {
                    { 1, "British" },
                    { 2, "French" },
                    { 3, "American" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Birthday", "FirstName", "LastName", "NationalityId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 25, 13, 47, 15, 584, DateTimeKind.Local).AddTicks(5951), "Larry", "Losser", 1 },
                    { 2, new DateTime(1970, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simon", "Pegg", 1 },
                    { 3, new DateTime(1976, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benedict", "Cumberbatch", 1 },
                    { 4, new DateTime(1948, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean", "Reno", 2 },
                    { 5, new DateTime(1980, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "Pine", 3 },
                    { 6, new DateTime(1966, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "JJ", "Abrams", 3 }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "PersonId", "MovieId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "PersonId", "MovieId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DirectorId", "ReleaseDate", "Title" },
                values: new object[] { 1, 6, new DateTime(2015, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: The Force Awakens" });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "PersonId", "MovieId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_People_NationalityId",
                table: "People",
                column: "NationalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
