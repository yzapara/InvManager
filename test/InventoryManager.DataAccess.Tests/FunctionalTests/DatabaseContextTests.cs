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
                UseSqlServer(System.Environment.GetEnvironmentVariable("SqlConSring")).
                Options;
        }

        [Fact]
        public void Property_Add_Success()
        {
            var name = "property name";
            var description = "property description";
            var type = "property type";

            using (var context = new DatabaseContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Property.Add(new Property() { Name = name, Description = description, DataType = type });

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(options))
            {
                var property = context.Property.Single();
                Assert.Equal(name, property.Name);
                Assert.Equal(description, property.Description);
                Assert.Equal(type, property.DataType);
            }
        }

        [Fact]
        public void Property_AddRange_Success()
        {
            var name1 = "property 1 name";
            var name2 = "property 2 name";
            var description1 = "property 1 description";
            var description2 = "property 2 description";
            var type1 = "property 1 type";
            var type2 = "property 2 type";

            using (var context = new DatabaseContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var properties = new[]
                {
                    new Property() { Name = name1, Description = description1, DataType = type1 },
                    new Property() { Name = name2, Description = description2, DataType = type2 }
                };
                context.Property.AddRange(properties);

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(options))
            {
                var property1 = context.Property.Where(property => property.Id == 1).Single();
                Assert.Equal(name1, property1.Name);
                Assert.Equal(description1, property1.Description);
                Assert.Equal(type1, property1.DataType);

                var property2 = context.Property.Where(property => property.Id == 2).Single();
                Assert.Equal(name2, property2.Name);
                Assert.Equal(description2, property2.Description);
                Assert.Equal(type2, property2.DataType);
            }
        }
    }
}
