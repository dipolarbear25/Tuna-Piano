using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tuna_Piano.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SongGenres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "integer", nullable: false),
                    SongsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresID, x.SongsID });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsID",
                        column: x => x.SongsID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ID", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 25, "American heavy metal band from Huntington Beach, California, formed in 1999. The band's current lineup consists of vocalist M. Shadows, rhythm guitarist Zacky Vengeance, lead guitarist Synyster Gates, bassist Johnny Christ, and drummer Brooks Wackerman.", "Avenged Sevenfold" },
                    { 2, 18, "Whitechapel is an American deathcore band from Knoxville, Tennessee. The band is named after the Whitechapel district in East London, England, where Jack the Ripper committed a series of murders. The group comprises vocalist Phil Bozeman, lead guitarist Ben Savage, rhythm guitarist Alex Wade, bassist Gabe Crisp and third guitarist Zach Householder.", "Whitechapel" },
                    { 3, 17, "Fit for an Autopsy is an American deathcore band from Jersey City, New Jersey, formed in 2008. The band consists of guitarists Pat Sheridan, Will Putney and Tim Howley, drummer Josean Orta, vocalist Joe Badolato, and bassist Peter \"Blue\" Spinazola.", "Fit For An Autopsy" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Heavy Metal" },
                    { 2, "Deathcore" }
                });

            migrationBuilder.InsertData(
                table: "SongGenres",
                columns: new[] { "ID", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 1, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "ID", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Nightmare", 1, 656, "Save Me" },
                    { 2, "Kin", 2, 336, "Anticure" },
                    { 3, "Oh What The Future Holds", 3, 284, "Far from Heaven" },
                    { 4, "Nightmare", 1, 315, "Natural Born Killer" },
                    { 5, "Hickory Creek", 2, 243, "Hickory Creek" },
                    { 6, "The Sea Of Tragic Beasts", 3, 296, "Nampalm Dreams" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsID",
                table: "GenreSong",
                column: "SongsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "SongGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
