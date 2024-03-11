namespace TunaPiano.Models;

public class SongGenre
{
	public int ID { get; set; }
	public int SongId { get; set; }
	public int GenreId { get; set; }
	public Genre? Genre { get; set; }
}