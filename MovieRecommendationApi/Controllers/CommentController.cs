using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly ICommentService _commentService;
        public CommentsController(ILogger<CommentsController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }
        [Authorize (Roles = "Customer")]
        [HttpPost]
        public IActionResult Create(CreateCommmentRequestModel model)
        {
            var response = _commentService.Create(model);
            if (response)
            {
                return Created();
            }
            return BadRequest();
        }
        [Authorize (Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _commentService.GetAllComments();
            if(response != null )
            {
                return Ok(response);
            }
            return NoContent();
        }
        [Authorize (Roles = "Customer")]
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var comments = _commentService.GetComment(id);
            if(comments != null)
            {
                return Ok(comments);
            }
            return NotFound();
        }
        [Authorize (Roles = "Customer")]
        [HttpPut("{id}")]
        public IActionResult Update(string id, UpdateCommentRequestModel model)
        {
            var comments = _commentService.UpdateComment(model);
            if (comments)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var comments = _commentService.DeactivateComment(id);
            if (comments)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}