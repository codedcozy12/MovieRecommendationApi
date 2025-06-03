namespace MovieRecommendationApi.Domain
{
    public class Comment : BaseEntities
    {
        public required string UserId { get; set; }
        public required string CommentNote { get; set; }
        public required string MovieId { get; set; }
    }
}
