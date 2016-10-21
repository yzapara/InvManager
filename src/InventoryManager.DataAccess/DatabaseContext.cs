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

        protected DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options)
        {
        }

        private static Dictionary<string, DatabaseContext> databaseContexts = new Dictionary<string, DatabaseContext>();
        private static object databaseContextsSync = new object();

        public static DatabaseContext GetOrCreate(string contextId)
        {
            lock (databaseContextsSync)
            {
                if (!databaseContexts.ContainsKey(contextId))
                {
                    var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                    var options = optionsBuilder.UseSqlServer(contextId).Options;
                    var context = contextId == "dev" ? new DatabaseContext() : new DatabaseContext(options); // TODO: Correct to use in dedug and release.
                    databaseContexts.Add(contextId, context);
                }
                return databaseContexts[contextId];
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
