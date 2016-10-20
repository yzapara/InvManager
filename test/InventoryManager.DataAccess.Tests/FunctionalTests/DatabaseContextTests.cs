using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InventoryManager.DataAccess.Tests.FunctionalTests
{
    public class DatabaseContextTests
    {
        private readonly DbContextOptions<DatabaseContext> options;

        public DatabaseContextTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            options = optionsBuilder.
                UseSqlServer(@"Data Source = 192.168.122.10\MSSQL14AMTOSS; Initial Catalog = InvMngDevTests; User ID = sa; Password = qwerty_123;").
                Options;
        }

        [Fact]
        public void Database_Recreate_Success()
        {
            using (var context = new DatabaseContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
