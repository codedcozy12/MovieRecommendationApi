using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Migrations;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly ILogger<RatingController> _logger;
        private readonly IRatingService _ratingService;
        public RatingController(ILogger<RatingController> logger, IRatingService ratingService)
        {
            _logger = logger;
            _ratingService = ratingService;
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult CreateRating(CreateRatingRequestModel model)
        {
            var response = _ratingService.CreateRating(model);
            if(response)
            {
                return Created();
            }
            return BadRequest();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _ratingService.GetAllRating();
            if(response != null )
            {
                return Ok(response);
            }
            return NoContent();
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var rating = _ratingService.MovieRating(id);
            if(rating != null)
            {
                return Ok(rating);
            }
            return NotFound();
        }
       
        [Authorize(Roles = "Customer")]
        [HttpPut("{id}")]
        public IActionResult Update(string id, UpdateRatingRequestModel model)
        {
            var rating = _ratingService.UpdateRating(model);
            if (rating)
            {
                return Ok();
            }
            return BadRequest();
        }
           [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rating = _ratingService.DeleteRating(id);
            if (rating)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}