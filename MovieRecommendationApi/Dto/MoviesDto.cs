using System.ComponentModel.DataAnnotations;
using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi.Dto
{
    public class MoviesDto
    {
        public string? Title { get; set; }
        public required string CategoryId { get; set; }
        public string Id { get; init; }
        public DateTime DateCreated { get; init; }
        public DateTime DateModified { get; set; }
        public string? CreatedBy { get; set; }
        public double Score { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public required string ImageUrl { get; set; }
        public required string MovieUrl{ get; set; }
    }
    public class CreateMovieRequestModel
    {
        public required string Title { get; set; }
        public required string CategoryId { get; set; }
        public required IFormFile Image { get; set; }
        public required string MovieUrl { get; set; }
    }
    public class UpdateMoviesRequestModel
    {
        public string? Title { get; set; }
        public required string UpdatedTitle { get; set; }
    }
}
