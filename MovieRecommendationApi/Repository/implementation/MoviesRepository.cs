using Microsoft.EntityFrameworkCore;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Repository.Interface;
using Mysqlx.Expr;

namespace MovieRecommendationApi.Repository.implementation
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieContext _context;
        public MoviesRepository(MovieContext context)
        {
            _context = context;
        }
        public bool CreateMovies(Movies movies)
        {
           _context.Set<Movies>().Add(movies);
            return true;
        }
        public bool DeleteMovies(Movies movies)
        {
            _context.Set<Movies>().Update(movies);
            return true;
        }

        public List<Movies> GetAllMovies()
        {
           return _context.Set<Movies>().AsNoTracking().Where(x => x.IsDeleted == false).ToList();
        }

        public Movies? GetMovie(string id)
        {
            return _context.Set<Movies>()
            .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public List<Movies> GetMoviesByCategory(string id)
        {
            return _context.Set<Movies>().AsNoTracking().Where(x => x.CategoryId == id && x.IsDeleted == false).ToList();
        }

        public Movies? GetMoviesByTitle(string title)
        {
            return _context.Set<Movies>().FirstOrDefault(x => x.Title == title && x.IsDeleted == false); 
        }

        public bool UpdateMovies(Movies movies)
        {
            _context.Update(movies);
            return true;
        }
    }
}
