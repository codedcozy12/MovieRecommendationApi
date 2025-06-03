using Microsoft.Extensions.Logging;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.Interface;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;
        public UserService(IUserRepository userRepository,ILogger<UserService> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public bool DeActivateUser(string id)
        {
            var users = _userRepository.GetUser(id);
            if (users == null)
            {
                _logger.LogError("Null Reference");
                return false;
            }
            users.IsDeleted = true;
             _userRepository.UpdateUser(users);
             _unitOfWork.SaveChanges();
             return true;
        }
        public UserDto GetUser(string id)
        {
            var users = _userRepository.GetUser(id);
            if (users == null)
            {
                return null;
            }
            return new UserDto
            {
                Id = users.Id,
                Email = users.Email,
                Role = users.Role
            };
        }
        public UserDto? Login(LoginUserRequestModel model)
        {
            var user = _userRepository.GetUserByEmail(model.Email);
            if(user is null)
            return null;
            if(user.Password == _userRepository.HashPassword(model.Password))
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role
                }; 
            }
            return null;
        }
    }
}