using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Auth
{
    public interface IAuthService
    {
         string GenerateJwtToken(UserDto userDto);
    }
}