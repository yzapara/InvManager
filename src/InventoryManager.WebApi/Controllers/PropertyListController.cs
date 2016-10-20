using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PropertyListController : Controller
    {
        private string connectionString = string.Empty;

        // GET api/propertylist
        [HttpGet]
        public IEnumerable<PropertyList> Get()
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            return context.PropertyList;
        }

        // GET api/propertylist/5
        [HttpGet("{id}")]
        public PropertyList Get(int id)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            return context.PropertyList.SingleOrDefault(item => item.Id == id);
        }

        // POST api/propertylist
        [HttpPost]
        public void Post([FromBody]PropertyList value)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            if (context.PropertyList.SingleOrDefault(item => item.Id == value.Id) != null)
                context.PropertyList.Attach(value);
            else
                context.PropertyList.Add(value);
            context.SaveChanges();
        }

        // PUT api/propertylist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PropertyList value)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            if (context.PropertyList.SingleOrDefault(item => item.Id == value.Id) != null)
                context.PropertyList.Attach(value);
            context.SaveChanges();
        }

        // DELETE api/propertylist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            var value = context.PropertyList.SingleOrDefault(item => item.Id == id);
            if (value != null)
                context.PropertyList.Remove(value);
        }
    }
}
