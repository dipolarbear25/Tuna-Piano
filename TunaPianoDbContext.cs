using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

public class TunaPianoDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<SongGenre> SongGenres { get; set; }

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new()
            {
                ID = 1,
                Name = "Avenged Sevenfold",
                Age = 25,
                Bio = "American heavy metal band from Huntington Beach, California, formed in 1999. The band's current lineup consists of vocalist M. Shadows, rhythm guitarist Zacky Vengeance, lead guitarist Synyster Gates, bassist Johnny Christ, and drummer Brooks Wackerman."
            },
            new()
            {
                ID = 2,
                Name = "Whitechapel",
                Age = 18,
                Bio = "Whitechapel is an American deathcore band from Knoxville, Tennessee. The band is named after the Whitechapel district in East London, England, where Jack the Ripper committed a series of murders. The group comprises vocalist Phil Bozeman, lead guitarist Ben Savage, rhythm guitarist Alex Wade, bassist Gabe Crisp and third guitarist Zach Householder."
            },
            new()
            {
                ID = 3,
                Name = "Fit For An Autopsy",
                Age = 17,
                Bio = "Fit for an Autopsy is an American deathcore band from Jersey City, New Jersey, formed in 2008. The band consists of guitarists Pat Sheridan, Will Putney and Tim Howley, drummer Josean Orta, vocalist Joe Badolato, and bassist Peter \"Blue\" Spinazola."
            }
        });

        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new()
            {
                ID = 1,
                Description = "Heavy Metal"
            },
            new()
            {
                ID = 2,
                Description = "Deathcore"
            }
        });

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new()
            {
                ID = 1,
                Title = "Save Me",
                ArtistId = 1,
                Album = "Nightmare",
                Length = 656,
            },
            new()
            {
                ID = 2,
                Title = "Anticure",
                ArtistId = 2,
                Album = "Kin",
                Length = 336,
            },
            new() 
            { 
                ID = 3,
                Title = "Far from Heaven",
                ArtistId = 3,
                Album = "Oh What The Future Holds",
                Length = 284,
            },
            new()
            {
                ID = 4,
                Title = "Natural Born Killer",
                ArtistId = 1,
                Album = "Nightmare",
                Length = 315,
            },
            new()
            {
                ID = 5,
                Title = "Hickory Creek",
                ArtistId = 2,
                Album = "Hickory Creek",
                Length = 243,
            },
            new()
            {
                ID = 6,
                Title = "Nampalm Dreams",
                ArtistId = 3,
                Album = "The Sea Of Tragic Beasts",
                Length = 296,
            }
        });

        modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
        {
            new()
            {
                ID = 1,
                SongId = 1,
                GenreId = 1,
            },
            new()
            {
                ID = 2,
                SongId = 1,
                GenreId = 1,
            },
            new()
            {
                ID = 3,
                SongId = 1,
                GenreId = 1,
            },

        });
    }
}

