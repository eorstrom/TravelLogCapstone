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
        public class AppUsersController : Controller
        {
            private TravelLogContext _context;

            public AppUsersController(TravelLogContext context)
            {
                _context = context;
            }

            // GET: api/values
            [HttpGet]
            public IActionResult Get([FromQuery] string username)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IQueryable<AppUsers> users = from user in _context.AppUsers
                                                 select new AppUsers
                                                 {
                                                     AppUserId = user.AppUserId,
                                                     Username = user.Username,
                                                     Email = user.Email
                                                 };

                if (username != null)
                {
                    users = users.Where(g => g.Username == username);
                }

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }

            // GET api/values/5
            [HttpGet("{id}", Name = "GetAppUser")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/values
            [HttpPost]
            public IActionResult Post([FromBody]AppUsers user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var existingUser = from u in _context.AppUsers
                                   where u.Username == user.Username
                                   select u;

                if (existingUser.Count<AppUsers>() > 0)
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }


                _context.AppUsers.Add(user);

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (UserExists(user.AppUserId))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtRoute("GetAppUser", new { id = user.AppUserId }, user);
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

            private bool UserExists(int id)
            {
                return _context.AppUsers.Count(e => e.AppUserId == id) > 0;
            }
        }
    }
