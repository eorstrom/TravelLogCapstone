using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelLogCapstone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelLogCapstone.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class RestaurantsController : Controller
    {
        private TravelLogContext _context;

        public RestaurantsController(TravelLogContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Restaurants> restaurants = from restaurant in _context.Restaurants
                                                  select new Restaurants
                                                  {
                                                      RestaurantId = restaurant.RestaurantId,
                                                      Name = restaurant.Name,
                                                      Address = restaurant.Address,
                                                      FoodCategory = restaurant.FoodCategory,
                                                      Visited = restaurant.Visited,
                                                      CityId = restaurant.CityId
                                                  };

            if (name != null)
            {
                restaurants = restaurants.Where(g => g.Name == name);
            }

            //if (Restaurants == null)
            {
                //    return NotFound();
                //}

                return Ok(restaurants);
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRestaurant")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurants restaurant = _context.Restaurants.Single(m => m.RestaurantId == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Restaurants restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //var existingRestaurant = from r in _context.Restaurants
            //                         where r.Name == r.Name
            //                         select r;

            //if (existingRestaurant.Count<Restaurants>() > 0)
            //{
            //    return new StatusCodeResult(StatusCodes.Status409Conflict);
            //}


            _context.Restaurants.Add(restaurant);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RestaurantExists(restaurant.RestaurantId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetRestaurant", new { id = restaurant.RestaurantId }, restaurant);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Count(e => e.RestaurantId == id) > 0;
        }
    }
}
