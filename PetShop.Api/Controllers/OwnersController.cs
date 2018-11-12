using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShop.Core.UIService;

namespace PetShop.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owners
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAll();
        }

        // GET: api/Owners/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.Get(id);
        }

        // POST: api/Owners
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner value)
        {
            Owner owner = value;
            if (string.IsNullOrEmpty(owner.name))
            {
                return BadRequest("Name is required for creating Owner");
            }
            return _ownerService.Create(owner);
        }

        // PUT: api/Owners/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.id)
            {
                return BadRequest("Enter the right id");
            }
            return Ok(_ownerService.Update(owner));
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            Owner owner = _ownerService.Delete(id);
            if (owner == null)
            {
                return BadRequest("Did not find the Owner");
            }
            return Ok("The owner with an id of " + id + " has been deleted.");
        }
    }
}
