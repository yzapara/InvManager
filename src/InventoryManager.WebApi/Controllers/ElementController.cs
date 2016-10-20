using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ElementController : Controller
    {
        private string connectionString = string.Empty;

        // GET api/element
        [HttpGet]
        public IEnumerable<Element> Get()
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            return context.Element;
        }

        // GET api/element/5
        [HttpGet("{id}")]
        public Element Get(int id)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            return context.Element.SingleOrDefault(item => item.Id == id);
        }

        // POST api/element
        [HttpPost]
        public void Post([FromBody]Element value)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            if (context.Element.SingleOrDefault(item => item.Id == value.Id) != null)
                context.Element.Attach(value);
            else
                context.Element.Add(value);
            context.SaveChanges();
        }

        // PUT api/element/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Element value)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            if (context.Element.SingleOrDefault(item => item.Id == value.Id) != null)
                context.Element.Attach(value);
            context.SaveChanges();
        }

        // DELETE api/element/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = DatabaseContext.GetOrCreate(connectionString);
            var value = context.Element.SingleOrDefault(item => item.Id == id);
            if (value != null)
                context.Element.Remove(value);
        }
    }
}
