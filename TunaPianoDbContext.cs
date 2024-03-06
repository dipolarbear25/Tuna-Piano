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
                Name = "Avenged Sevenfold"
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
                SellerId = 1,
                ProductName = "Movement Sensor Lamp",
                CategoryId = 1,
                QuantityInStock = 2,
                Description = "This item is a lamp that has no buttons to turn on, but the bottom rim of the lamp shade has a movement sensor to detect when someone or something walks by, thus turning it on.",
                PricePerUnit = 25.00M,
                TimePosted = new DateTime(2024, 2, 16)
            },
            new()
            {
                ID = 2,
                SellerId = 2,
                ProductName = "Aluminum bat",
                CategoryId = 2,
                QuantityInStock = 5,
                Description = "A baseball bat made out of aluminum.",
                PricePerUnit = 40.00M,
                TimePosted = new DateTime(2024, 2, 4)
            }
        });

        modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
        {
            new()
            {
                ID = 1,
                Email = "Jjonna@dailybugle.com",
                Name = "John Jonah Jameson Jr",
                IsSeller = true
            },
            new()
            {
                ID = 2,
                Email = "AuntieMayLovesBen@gmail.com",
                Name = "Maybelle Parker-Jameson",
                IsSeller = false
            },
            new()
            {
                ID = 3,
                Email = "PeterParker@ESU.com",
                Name = "Peter Parker",
                IsSeller = true
            }
        });
    }
}

