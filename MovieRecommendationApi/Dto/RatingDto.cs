namespace MovieRecommendationApi.Dto
{
    public class RatingDto
    {
        public required string UserId { get; set; }
        public required string MovieId{get; set;}
        public int Score{get; set;}
        public string Id { get; init; }
        public DateTime DateCreated { get; init; } 
        public DateTime DateModified { get; set; } 
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class CreateRatingRequestModel
    {
        public required string MovieId{get; set;}
        public int Score{get; set;}

    }
    public class UpdateRatingRequestModel
    {
        public int Score{get; set;}
        public int UpdatedScore{get; set;}
    }
}