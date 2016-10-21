using InventoryManager.DataAccess;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeaderedProperyListController : Controller
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>
        {
            { "id","Id" },
            { "name","Name" },
            { "description","Description" }
        };

        private readonly List<PropertyList> _items = new List<PropertyList>(new[]
        {
            new PropertyList() {Id=0, Name="property_list_0_name", Description="property_list_0_description"},
            new PropertyList() {Id=1, Name="property_list_1_name", Description="property_list_1_description"},
            new PropertyList() {Id=2, Name="property_list_2_name", Description="property_list_2_description"},
        });

        // GET api/headeredpropertylist
        [HttpGet]
        public object Get()
        {
            return new { headers = _headers, data = _items };
        }

        // GET api/headeredpropertylist/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return new { headers = _headers, data = _items.Where(items => items.Id == id) };
        }
    }
}
