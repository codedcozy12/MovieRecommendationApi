using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesService _movieService;
        private readonly IRatingService _ratingService;
        private readonly ICommentService _commentService;
        public MoviesController(ILogger<MoviesController> logger, IMoviesService moviesService, IRatingService ratingService, ICommentService commentService)
        {
            _logger = logger;
            _movieService = moviesService;
            _ratingService = ratingService;
            _commentService = commentService;
        }
        [Authorize (Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateMovie([FromForm] CreateMovieRequestModel model)
        {
            var response = _movieService.CreateMovies(model);
            if(response)
            {
                return Created();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _movieService.GetAllMovies();
            if(response != null )
            {
                return Ok(response);
            }
            return NoContent();
        }
        [Authorize (Roles = "Admin,Customer")]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var movie = _movieService.GetMovie(id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
        [HttpGet("{id}/Comments")]
        public IActionResult GetMovieComments(string id)
        {
             var response = _commentService.GetCommentsByMovie(id);
            if(response != null )
            {
                return Ok(response);
            }
            return NoContent();
        }
         [HttpGet("Movie/{id}/Rating")]
        public IActionResult MovieRating(string id)
        {
            var rating = _ratingService.MovieRating(id);
            if(rating != null)
            {
                return Ok(rating);
            }
            return NotFound();
        }
        [Authorize (Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(string id, UpdateMoviesRequestModel model)
        {
            var movie = _movieService.UpdateMovies(model);
            if (movie)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize (Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var movie = _movieService.DeleteMovies(id);
            if (movie)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}