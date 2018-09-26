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
    public class ColorsController : ControllerBase
    {

        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: api/Colors
        [HttpGet]
        public ActionResult<IEnumerable<Color>> Get()
        {
            return _colorService.GetAll();
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public ActionResult<Color> Get(int id)
        {
            return _colorService.Get(id);
        }

        // POST: api/Colors
        [HttpPost]
        public ActionResult<Color> Post([FromBody] Color value)
        {
            Color color = value;
            if (string.IsNullOrEmpty(color.name))
            {
                return BadRequest("A name is required");
            }
            if (string.IsNullOrEmpty(color.hexcode))
            {
                return BadRequest("A hexcode is required");
            }
            return _colorService.Create(color);
        }

        // PUT: api/Colors/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            return "Not yet implemented";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return "Not yet implemented";
        }
    }
}
