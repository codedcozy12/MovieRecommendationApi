using System.Security.Claims;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _http;
        public CurrentUser(IHttpContextAccessor http)
        {
            _http = http;
        }
        public string GetCurrentUser()
        {
            var emailClaim = _http.HttpContext?.User?.FindFirst(ClaimTypes.Email);
            if (emailClaim == null)
                throw new Exception("Email claim not found.");
            return emailClaim.Value;

        }

    }
}