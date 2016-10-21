using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using InventoryManager.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.WebApi.Repositories
{
    public interface IPropertiesRepository
    {
        void Add(Property item);
        IEnumerable<Property> GetAll();
        Property Find(int id);
        Property Remove(int id);
        void Update(Property item);
    }

    public class PropertiesRepository : IPropertiesRepository
    {
        private static ConcurrentDictionary<int, Property> _properties = new ConcurrentDictionary<int, Property>();

        public PropertiesRepository()
        {
            Add(new Property() { Name = "property_0_name", Description = "property_0_description"/*, Datatype = "property_0_data_type"*/ });
            Add(new Property() { Name = "property_1_name", Description = "property_1_description"/*, Datatype = "property_1_data_type"*/ });
            Add(new Property() { Name = "property_2_name", Description = "property_2_description"/*, Datatype = "property_2_data_type"*/ });
        }

        public void Add(Property item)
        {
            item.Id = _properties.Count > 0 ? _properties.Max(t => t.Key) + 1 : 0;
            _properties[item.Id] = item;
        }

        public void Update(Property item)
        {
            _properties[item.Id] = item;
        }
        
        Property IPropertiesRepository.Find(int id)
        {
            Property item;
            _properties.TryGetValue(id, out item);
            return item;
        }

        IEnumerable<Property> IPropertiesRepository.GetAll()
        {
            return _properties.Values;
        }

        Property IPropertiesRepository.Remove(int id)
        {
            Property item;
            _properties.TryRemove(id, out item);
            return item;
        }
    }
}
