using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShop.Core.IService;
using PetShop.Core.UIService;

namespace PetShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.GetAll();
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> Post([FromBody] UserTemp value)
        {
            return _userService.New(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = _userService.Delete(id);
            if (user == null)
            {
                return BadRequest("Did not find the User");
            }
            return Ok("The user with an id of " + id + " has been deleted.");
        }
    }
}
