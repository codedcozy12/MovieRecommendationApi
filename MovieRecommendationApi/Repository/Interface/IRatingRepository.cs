using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi.Repository.Interface
{
    public interface IRatingRepository
    {
         bool CreateRating(Rating rating);
         Rating? GetRating(string id);
         double MovieRating(string id);
         List<Rating> GetAllRating();
         bool UpdateRating(Rating rating);
        bool DeleteRating(Rating rating);   
    }
}