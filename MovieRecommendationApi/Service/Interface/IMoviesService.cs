using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface IMoviesService
    {
        bool CreateMovies(CreateMovieRequestModel createMovieRequestModel);
        MoviesDto GetMovie(string id);
        Movies? GetMoviesByTitle(string title);
        List<MoviesDto> GetAllMovies();
        List<MoviesDto> GetMoviesByCategory(string id);
        bool UpdateMovies(UpdateMoviesRequestModel updateMoviesRequestModel);
        bool DeleteMovies(string id);
    }
}