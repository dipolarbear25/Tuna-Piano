namespace TunaPiano.Models;

public class Song
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public string Album { get; set;}
    public int Length { get; set; }
    public ICollection<Genre> Genres { get; set;}
}