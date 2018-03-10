using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurants.Repositories;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        IRestaurantRepository _repo;
        ILogger _logger;

        public RestaurantsController(IRestaurantRepository repo, ILogger<RestaurantsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            _logger.LogInformation(new EventId(2112, "Restaurants.GetMany()"), "Request for many restaurant documents.");

            var result = _repo.GetMany();

            if (result == null || result.Count == 0)
            {
                _logger.LogWarning(new EventId(204, "Restaurants.GetMany()"), "Requested content not found.");
                return NoContent();
            }

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{rest_id}")]
        public IActionResult Get(int rest_id)
        {
            _logger.LogInformation(new EventId(2113, "Restaurants.GetOne({rest_id})"), "Request for a single restaurant document.");

            var result = _repo.GetOne(rest_id.ToString());

            if (result == null)
            {
                _logger.LogWarning(new EventId(204, "Restaurants.GetOne({rest_id})"), "Requested content not found.");
                return NoContent();
            }

            return Ok(result);
        }
    }
}