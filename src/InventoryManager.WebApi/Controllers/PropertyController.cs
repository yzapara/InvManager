﻿using InventoryManager.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private readonly List<Property> properties = new List<Property>(new[]
        {
            new Property() {Id=0, Name="property_0_name",Description="property_0_description",DataType="property_0_data_type" },
            new Property() {Id=1, Name="property_1_name",Description="property_1_description",DataType="property_1_data_type" },
            new Property() {Id=2, Name="property_2_name",Description="property_2_description",DataType="property_2_data_type" },
        });

        // GET api/property
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return properties;
        }

        // GET api/property/5
        [HttpGet("{id}")]
        public Property Get(int id)
        {
            return properties.SingleOrDefault(property => property.Id == id);
        }

        // POST api/property
        [HttpPost]
        public void Post([FromBody]Property value)
        {
            value.Id = properties.Count;
            properties.Add(value);
        }

        // PUT api/property/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Property value)
        {
            value.Id = id;
            properties[id] = value;
        }

        // DELETE api/property/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            properties.RemoveAt(id);
        }
    }
}