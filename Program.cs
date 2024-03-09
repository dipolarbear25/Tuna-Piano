using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/songs", (TunaPianoDbContext db) =>
{
    return db.Songs.ToList();
});

app.MapDelete("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
{
    Song deleteSongs = db.Songs.SingleOrDefault(songToDelete => songToDelete.ID == id);
    if (deleteSongs == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(deleteSongs);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/songs/{id}", (TunaPianoDbContext db, int id, Song updateSong) =>
{
    Song songUpdated = db.Songs.SingleOrDefault(product => product.ID == id);

    if (songUpdated == null)
    {
        return Results.NotFound();
    }

    songUpdated.Title = updateSong.Title;
    songUpdated.Album = updateSong.Album;
    songUpdated.Length = updateSong.Length;
    songUpdated.ArtistId = updateSong.ArtistId;

    db.SaveChanges();
    return Results.Ok();
});

app.MapGet("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
{
    var song = db.Songs
    .Include(s => s.Artist)
    .Include(s => s.Genres)
    .FirstOrDefault(s => s.ID == id);

    if (song == null)
    {
        return Results.NotFound(id);
    }

    var response = new
    {
        id = song.ID,
        title = song.Title,
        artist = new
        {
            id = song.Artist.ID,
            name = song.Artist.Name,
            age = song.Artist.Age,
            bio = song.Artist.Bio
        },
        album = song.Album,
        length = song.Length,
        genre = song.Genres.Select(genre => new
        {
            id = genre.ID,
            description = genre.Description,
        }).ToList()
    };

    return Results.Ok();
});


app.MapPost("/api/songs", (TunaPianoDbContext db, Song songs) =>
{
    db.Songs.Add(songs);
    db.SaveChanges();
    return Results.Created($"/api/songs/{songs.ID}", songs);
});

app.MapPost("/api/artists", (TunaPianoDbContext db, Artist newArtist) =>
{
    db.Artists.Add(newArtist);
    db.SaveChanges();
    return Results.Created($"/api/artists/{newArtist.ID}", newArtist);
});

app.MapDelete("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    var artist = db.Artists.SingleOrDefault(a => a.ID == id);
    if (artist == null)
    {
        return Results.NotFound();
    }
    db.Artists.Remove(artist);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/artists/{artistsId}", (TunaPianoDbContext db, int id, Artist updatedArtist) =>
{
    var artist = db.Artists.SingleOrDefault(a => a.ID == id);
    if (artist == null)
    {
        return Results.NotFound();
    }
    artist.Name = updatedArtist.Name;
    artist.Age = updatedArtist.Age;
    artist.Bio = updatedArtist.Bio;

    db.SaveChanges();
    return Results.Ok();
});

app.MapGet("/api/artists", (TunaPianoDbContext db) =>
{
    return db.Artists.ToList();
});

app.MapGet("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    var pID = db.Artists.FirstOrDefault(u => u.ID == id);

    if (pID == null)
    {
        return Results.NotFound("User not found.");
    }
    return Results.Ok(pID);
});

app.MapPost("/api/genres", (TunaPianoDbContext db, Genre newGenre) =>
{
    db.Genres.Add(newGenre);
    db.SaveChanges();
    return Results.Created($"/api/genres/{newGenre.ID}", newGenre);
});

app.MapDelete("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    var genre = db.Genres.SingleOrDefault(a => a.ID == id);
    if (genre == null)
    {
        return Results.NotFound();
    }
    db.Genres.Remove(genre);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/genres/{genreId}", (TunaPianoDbContext db, int id, Genre updatedGenre) =>
{
    var genre = db.Genres.SingleOrDefault(a => a.ID == id);
    if (genre == null)
    {
        return Results.NotFound();
    }
    genre.Description = updatedGenre.Description;

    db.SaveChanges();
    return Results.Ok();
});

app.MapGet("/api/genres", (TunaPianoDbContext db) =>
{
    return db.Genres.ToList();
});

app.MapGet("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    var pID = db.Genres.FirstOrDefault(u => u.ID == id);

    if (pID == null)
    {
        return Results.NotFound("User not found.");
    }
    return Results.Ok(pID);
});

app.Run();
