using MovieRecommendationApi.Domain;
namespace MovieRecommendationApi.Dto
{
    public class UserDto
    {
        public required string Email { get; set; }
        public required string Id { get; set; }
        public Role Role{get; set;}
    }
     public class LoginUserRequestModel
    {
        public required string Email{get; set;}
        public required string Password{get; set;}
    }
}