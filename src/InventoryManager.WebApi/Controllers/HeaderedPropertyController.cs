using InventoryManager.DataAccess;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using InventoryManager.WebApi.Repositories;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeaderedPropertyController : Controller
    {
        private IPropertiesRepository _items { get; set; }
        public HeaderedPropertyController(IPropertiesRepository todoItems)
        {
            _items = todoItems;
        }

        private Dictionary<string, string> _headers = new Dictionary<string, string>
        {
            { "id","Id" },
            { "name","Name" },
            { "description","Description" },
            { "dataType","Data Type" }
        };

        // GET api/headeredproperty
        [HttpGet]
        public object Get()
        {
            return new { headers = _headers, data = _items.GetAll() };
        }

        // GET api/headeredproperty/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return new { headers = _headers, data = _items.Find(id) };
        }
    }
}
