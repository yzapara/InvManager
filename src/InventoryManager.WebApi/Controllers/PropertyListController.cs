using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PropertyListController : Controller
    {
        private readonly List<PropertyList> items = new List<PropertyList>(new[]
        {
            new PropertyList() {Id=0, Name="property_list_0_name", Description="property_list_0_description"},
            new PropertyList() {Id=1, Name="property_list_1_name", Description="property_list_1_description"},
            new PropertyList() {Id=2, Name="property_list_2_name", Description="property_list_2_description"},
        });

        // GET api/propertylist
        [HttpGet]
        public IEnumerable<PropertyList> Get()
        {
            return items;
        }

        // GET api/propertylist/5
        [HttpGet("{id}")]
        public PropertyList Get(int id)
        {
            return items.SingleOrDefault(item => item.Id == id);
        }

        // POST api/propertylist
        [HttpPost]
        public void Post([FromBody]PropertyList value)
        {
            value.Id = items.Count;
            items.Add(value);
        }

        // PUT api/propertylist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PropertyList value)
        {
            value.Id = id;
            items[id] = value;
        }

        // DELETE api/propertylist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            items.RemoveAt(id);
        }
    }
}
