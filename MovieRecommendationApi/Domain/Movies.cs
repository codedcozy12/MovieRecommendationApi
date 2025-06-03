namespace MovieRecommendationApi.Domain
{
    public class Movies : BaseEntities
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required string CategoryId { get; set; }
        public required string MovieUrl { get; set; }
    }
}