using MovieRecommendationApi.Migrations;

namespace MovieRecommendationApi.Domain
{
    public class User : BaseEntities
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }
    }
}