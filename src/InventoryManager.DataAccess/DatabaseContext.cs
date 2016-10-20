using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManager.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Datatype> Datatype { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyList> PropertyList { get; set; }
        public DbSet<PropertyListToProperty> PropertyListToProperty { get; set; }
        public DbSet<Element> Element { get; set; }
        public DbSet<ElementToPropertyList> ElementToPropertyList { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options)
        {
        }

        private static Dictionary<string, DatabaseContext> databaseContexts = new Dictionary<string, DatabaseContext>();
        private static object databaseContextsSync = new object();

        public static DatabaseContext GetOrCreate(string connectionString)
        {
            lock (databaseContextsSync)
            {
                if (!databaseContexts.ContainsKey(connectionString))
                {
                    var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                    var options = optionsBuilder.UseSqlServer(connectionString).Options;
                    var context = new DatabaseContext(options);
                    databaseContexts.Add(connectionString, context);
                }
                return databaseContexts[connectionString];
            }
        }

        public static void Remove(string connectionString)
        {
            lock (databaseContextsSync)
            {
                databaseContexts.Remove(connectionString);
            }
        }
    }
}
