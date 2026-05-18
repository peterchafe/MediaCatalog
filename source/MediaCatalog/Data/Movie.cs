namespace MediaCatalog.Data;

// Step 3: Define the Movie Entity
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string ImdbLink { get; set; } = string.Empty;
    public string TmdbMovieId { get; set; } = string.Empty;
}