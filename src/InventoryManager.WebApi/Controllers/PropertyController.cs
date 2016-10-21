using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InventoryManager.WebApi.Repositories;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private IPropertiesRepository _items { get; set; }
        public PropertyController(IPropertiesRepository todoItems)
        {
            _items = todoItems;
        }

        // GET api/property
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return _items.GetAll();
        }

        // GET api/property/5
        [HttpGet("{id}", Name = "GetProperty")]
        public IActionResult Get(int id)
        {
            var item = _items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/property
        [HttpPost]
        public IActionResult Post([FromBody]Property item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _items.Add(item);
            return Get(item.Id);// TODO CreatedAtRoute("GetProperty", new { id = item.Id }, item);            
        }

        // PUT api/property/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Property item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _items.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _items.Update(item);
            return new NoContentResult();
        }

        // DELETE api/property/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _items.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _items.Remove(id);
            return new NoContentResult();
        }
    }
}
