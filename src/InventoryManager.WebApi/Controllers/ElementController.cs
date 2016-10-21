using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ElementController : Controller
    {
        private List<Element> items = new List<Element>(new[]
        {
            new Element() {Id=0, Name="element_0_name", Description="element_0_description" },
            new Element() {Id=1, Name="element_1_name", Description="element_1_description" },
            new Element() {Id=2, Name="element_2_name", Description="element_2_description" },
        });

        // GET api/element
        [HttpGet]
        public IEnumerable<Element> Get()
        {
            return items;
        }

        // GET api/element/5
        [HttpGet("{id}")]
        public Element Get(int id)
        {
            return items.SingleOrDefault(item => item.Id == id);
        }

        // POST api/element
        [HttpPost]
        public void Post([FromBody]Element value)
        {
            value.Id = items.Count;
            items.Add(value);
        }

        // PUT api/element/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Element value)
        {
            value.Id = id;
            items[id] = value;
        }

        // DELETE api/element/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            items.RemoveAt(id);
        }
    }
}
