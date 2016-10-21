using InventoryManager.DataAccess;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeaderedPropertyController : Controller
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>
        {
            { "id","Id" },
            { "name","Name" },
            { "description","Description" },
            { "dataType","Data Type" }
        };

        private readonly List<Property> _items = new List<Property>(new[]
        {
            new Property() {Id=0, Name="property_0_name",Description="property_0_description",DataType="property_0_data_type" },
            new Property() {Id=1, Name="property_1_name",Description="property_1_description",DataType="property_1_data_type" },
            new Property() {Id=2, Name="property_2_name",Description="property_2_description",DataType="property_2_data_type" },
        });

        // GET api/headeredproperty
        [HttpGet]
        public object Get()
        {
            return new { headers = _headers, data = _items };
        }

        // GET api/headeredproperty/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return new { headers = _headers, data = _items.Where(item => item.Id == id) };
        }
    }
}
