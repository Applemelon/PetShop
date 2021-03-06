﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShop.Core.UIService;
using Microsoft.AspNetCore.Authorization;

namespace PetShop.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/values
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAll();
        }

        // GET api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetById(id);
        }

        // POST api/values
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet value)
        {
            Pet pet = value;
            /*if (string.IsNullOrEmpty(pet.name))
            {
                return BadRequest("Name is required for creating Pet");
            }

            if (string.IsNullOrEmpty(pet.previousowner))
            {
                return BadRequest("Previous owner is required for creating Pet");
            }*/
            return _petService.Create(pet);
        }

        // PUT api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.id)
            {
                return BadRequest("Enter the right id");
            }
            return Ok(_petService.Update(pet));
        }

        // DELETE api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            Pet pet = _petService.Delete(id);
            if (pet == null)
            {
                return BadRequest("Did not find the Pet");
            }
            return Ok("The pet with an id of " + id + " has been deleted.");
        }
    }
}
