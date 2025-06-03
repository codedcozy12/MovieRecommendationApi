using Microsoft.EntityFrameworkCore;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Repository.Interface;

namespace MovieRecommendationApi.Repository.implementation
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieContext _context;
        public RatingRepository(MovieContext context)
        {
            _context = context;
        }
        public bool CreateRating(Rating rating)
        {
            _context.Set<Rating>().Add(rating);
            return true; 
        }
        public bool DeleteRating(Rating rating)
        {
            _context.Set<Rating>().Update(rating);
            return true;
        }
        public List<Rating> GetAllRating()
        {
            return _context.Set<Rating>().AsNoTracking().Where(x => x.IsDeleted == false).ToList();
        }
        public Rating? GetRating(string id)
        {
            return _context.Set<Rating>().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public double MovieRating(string id)
        {
            return _context.Set<Rating>()
                    .Where(r => r.MovieId == id)
                    .Select(r => r.Score)
                    .DefaultIfEmpty()
                    .Average();
        }


        public bool UpdateRating(Rating rating)
        {
            _context.Update(rating);
            return true;
        }

    }
}