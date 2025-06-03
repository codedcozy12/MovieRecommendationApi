using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Service.implementation;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;
        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        [HttpPost]
        public IActionResult Create(CreateCustomerRequestModel model)
        {
            var response = _customerService.Create(model);
            if (response)
            {
                return Created("Successful",response);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerService.GetAllCustomers();
            if(response != null )
            {
                return Ok(response);
            }
            return NoContent();
        }
         [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var customer = _customerService.GetCustomer(id);
            if(customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, UpdateCustomerRequestModel model)
        {
            var customer = _customerService.UpdateCustomer(model);
            if (customer)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var customer = _customerService.DeactivateCustomer(id);
            if (customer)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}