using System.Collections.ObjectModel;

namespace InventoryManager.WebApplication
{
    public class MultitenancyOptions
    {
        public Collection<AppTenant> Tenants { get; set; }
    }
}
