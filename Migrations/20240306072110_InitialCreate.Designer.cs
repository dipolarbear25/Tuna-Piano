﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tuna_Piano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    [Migration("20240306072110_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenresID")
                        .HasColumnType("integer");

                    b.Property<int>("SongsID")
                        .HasColumnType("integer");

                    b.HasKey("GenresID", "SongsID");

                    b.HasIndex("SongsID");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 25,
                            Bio = "American heavy metal band from Huntington Beach, California, formed in 1999. The band's current lineup consists of vocalist M. Shadows, rhythm guitarist Zacky Vengeance, lead guitarist Synyster Gates, bassist Johnny Christ, and drummer Brooks Wackerman.",
                            Name = "Avenged Sevenfold"
                        },
                        new
                        {
                            ID = 2,
                            Age = 18,
                            Bio = "Whitechapel is an American deathcore band from Knoxville, Tennessee. The band is named after the Whitechapel district in East London, England, where Jack the Ripper committed a series of murders. The group comprises vocalist Phil Bozeman, lead guitarist Ben Savage, rhythm guitarist Alex Wade, bassist Gabe Crisp and third guitarist Zach Householder.",
                            Name = "Whitechapel"
                        },
                        new
                        {
                            ID = 3,
                            Age = 17,
                            Bio = "Fit for an Autopsy is an American deathcore band from Jersey City, New Jersey, formed in 2008. The band consists of guitarists Pat Sheridan, Will Putney and Tim Howley, drummer Josean Orta, vocalist Joe Badolato, and bassist Peter \"Blue\" Spinazola.",
                            Name = "Fit For An Autopsy"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Heavy Metal"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Deathcore"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Album = "Nightmare",
                            ArtistId = 1,
                            Length = 656,
                            Title = "Save Me"
                        },
                        new
                        {
                            ID = 2,
                            Album = "Kin",
                            ArtistId = 2,
                            Length = 336,
                            Title = "Anticure"
                        },
                        new
                        {
                            ID = 3,
                            Album = "Oh What The Future Holds",
                            ArtistId = 3,
                            Length = 284,
                            Title = "Far from Heaven"
                        },
                        new
                        {
                            ID = 4,
                            Album = "Nightmare",
                            ArtistId = 1,
                            Length = 315,
                            Title = "Natural Born Killer"
                        },
                        new
                        {
                            ID = 5,
                            Album = "Hickory Creek",
                            ArtistId = 2,
                            Length = 243,
                            Title = "Hickory Creek"
                        },
                        new
                        {
                            ID = 6,
                            Album = "The Sea Of Tragic Beasts",
                            ArtistId = 3,
                            Length = 296,
                            Title = "Nampalm Dreams"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.SongGenre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("SongGenres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            GenreId = 1,
                            SongId = 1
                        },
                        new
                        {
                            ID = 2,
                            GenreId = 2,
                            SongId = 2
                        },
                        new
                        {
                            ID = 3,
                            GenreId = 2,
                            SongId = 3
                        },
                        new
                        {
                            ID = 4,
                            GenreId = 1,
                            SongId = 4
                        },
                        new
                        {
                            ID = 5,
                            GenreId = 2,
                            SongId = 5
                        },
                        new
                        {
                            ID = 6,
                            GenreId = 2,
                            SongId = 6
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("TunaPiano.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPiano.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
