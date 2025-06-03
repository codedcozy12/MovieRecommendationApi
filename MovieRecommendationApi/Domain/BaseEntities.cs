namespace MovieRecommendationApi.Domain
{
    public class BaseEntities
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; init; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}