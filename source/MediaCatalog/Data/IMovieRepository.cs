namespace MediaCatalog.Data;

public interface IMovieRepository
{
    Task<Movie?> GetMovieByIdAsync(int id);
    Task<Movie?> GetMovieByImdbLinkAsync(string imdbLink);
    Task<Movie?> AddMovieAsync(Movie movie);
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<Movie?> UpdateMovieAsync(Movie movie);
    Task<Movie?> DeleteMovieAsync(int id);
}