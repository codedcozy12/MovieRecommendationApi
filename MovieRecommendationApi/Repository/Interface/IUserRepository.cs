using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi.Repository.Interface
{
    public interface IUserRepository
    {
        bool Persist(User user); 
        bool CheckIfExists(string email);
        User? GetUser(string id);
        User? GetUserByEmail(string email);
        List<User> GetAllUsers();  
        bool DeActivateUser(User user);
        bool UpdateUser(User user);
        string HashPassword(string password);
    }
}