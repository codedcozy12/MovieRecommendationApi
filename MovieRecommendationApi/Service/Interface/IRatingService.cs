using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface IRatingService
    {
        bool CreateRating(CreateRatingRequestModel createRatingRequestModel);
        RatingDto? GetRating(string id);
        double MovieRating(string MovieId);
        List<RatingDto> GetAllRating();
        bool UpdateRating(UpdateRatingRequestModel updateRatingRequestModel);
        bool DeleteRating(string id);
    }
}