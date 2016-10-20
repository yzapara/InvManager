using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private string databaseId = "dev";

        // GET api/property
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            var context = DatabaseContext.GetOrCreate(databaseId);
            return context.Property;
        }

        // GET api/property/5
        [HttpGet("{id}")]
        public Property Get(int id)
        {
            var context = DatabaseContext.GetOrCreate(databaseId);
            return context.Property.SingleOrDefault(item => item.Id == id);
        }

        // POST api/property
        [HttpPost]
        public void Post([FromBody]Property value)
        {
            var context = DatabaseContext.GetOrCreate(databaseId);
            if (context.Property.SingleOrDefault(item => item.Id == value.Id) != null)
                context.Property.Attach(value);
            else
                context.Property.Add(value);
            context.SaveChanges();
        }

        // PUT api/property/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Property value)
        {
            var context = DatabaseContext.GetOrCreate(databaseId);
            if (context.Property.SingleOrDefault(item => item.Id == value.Id) != null)
                context.Property.Attach(value);
            context.SaveChanges();
        }

        // DELETE api/property/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = DatabaseContext.GetOrCreate(databaseId);
            var value = context.Property.SingleOrDefault(item => item.Id == id);
            if (value != null)
                context.Property.Remove(value);
        }
    }
}
