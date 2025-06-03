using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Service.implementation;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMoviesService _moviesService;
        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService, IMoviesService moviesService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _moviesService = moviesService;
        }
        [Authorize (Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryRequestModel model)
        {
            var response = _categoryService.Create(model);
            if(!response)
            {
                return BadRequest();
            }
            return Created();
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _categoryService.GetAllCategories();
            if(response != null )
            {
                return Ok(response);
            }
            return NoContent();
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var categories = _categoryService.GetCategory(id);
            if(categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }
          [HttpGet ("{id}/Movies")]
        public IActionResult GetMoviesByCategory(string id)
        {
            var movies = _moviesService.GetMoviesByCategory(id);
            if (movies != null)
            {
                return Ok(movies);
            }
            return NotFound();
        }
        [Authorize (Roles = "Admin")]
        [HttpPut("{id}")]
         public IActionResult Update(string id, UpdateCategoryRequestModel model)
        {
            var categories = _categoryService.UpdateCategory(model);
            if (categories)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize (Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var comments = _categoryService.DeleteCategory(id);
            if (comments)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}