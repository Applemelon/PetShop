using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShop.Core.UIService;

namespace PetShop.Api.Controllers
{
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
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAll();
        }

        // GET: api/Owners/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.Get(id);
        }

        // POST: api/Owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner value)
        {
            Owner owner = new Owner();
            if (string.IsNullOrEmpty(owner.name))
            {
                return BadRequest("Name is required for creating Owner");
            }
            return _ownerService.Create(owner);
        }

        // PUT: api/Owners/5
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
