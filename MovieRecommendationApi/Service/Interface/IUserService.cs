using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface IUserService
    {
        UserDto GetUser(string id);
         UserDto? Login(LoginUserRequestModel model);
        bool DeActivateUser(string id);
    }
}