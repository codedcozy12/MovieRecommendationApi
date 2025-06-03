using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApi.Auth;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService _userService, ICustomerService customerService, IAuthService authService):ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginUserRequestModel model)
        {
            var response = _userService.Login(model);
            if(response != null)
            {
                var token = authService.GenerateJwtToken(response);
                return Ok(new{Token = token});
            }
            return BadRequest("Invalid Credentials");
        }
    }
}