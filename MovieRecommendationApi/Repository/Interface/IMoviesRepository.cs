using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi.Repository.Interface
{
    public interface IMoviesRepository
    {
        bool CreateMovies(Movies movies);
        Movies? GetMovie(string id);
        Movies? GetMoviesByTitle(string title);
        List<Movies> GetAllMovies();
        List<Movies> GetMoviesByCategory(string id);
        bool UpdateMovies(Movies movies);
        bool DeleteMovies(Movies movies);
    }
}
