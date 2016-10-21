using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InventoryManager.DataAccess;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeaderedElementController : Controller
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>
        {
            { "id","Id" },
            { "name","Name" },
            { "description","Description" }
        };

        private readonly List<Element> _items = new List<Element>(new[]
        {
            new Element() {Id=0, Name="element_0_name", Description="element_0_description" },
            new Element() {Id=1, Name="element_1_name", Description="element_1_description" },
            new Element() {Id=2, Name="element_2_name", Description="element_2_description" },
        });

        // GET api/headeredelement
        [HttpGet]
        public object Get()
        {
            return new { headers = _headers, data = _items };
        }

        // GET api/headeredelement/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return new { headers = _headers, data = _items.Where(items => items.Id == id) };
        }
    }
}
