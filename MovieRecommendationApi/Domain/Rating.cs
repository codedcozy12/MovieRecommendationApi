namespace MovieRecommendationApi.Domain
{
    public class Rating : BaseEntities
    {
        public required string UserId { get; set; }
        public required string MovieId{get; set;}
        public int Score{get; set;}
    }
}