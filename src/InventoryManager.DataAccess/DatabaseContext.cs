using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryManager.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyList> PropertyList { get; set; }
        public DbSet<PropertyListToProperty> PropertyListToProperty { get; set; }
        public DbSet<Element> Element { get; set; }
        public DbSet<ElementToPropertyList> ElementToPropertyList { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options)
        {
        }
    }
}
