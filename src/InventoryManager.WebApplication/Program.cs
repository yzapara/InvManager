using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InventoryManager.WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("hosting.json", optional: true)
      .Build();

            var host = new WebHostBuilder()
                .UseKestrel().UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
               // .UseUrls("http://localhost:60000", "http://localhost:60001", "http://localhost:60002", "http://localhost:60003")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
