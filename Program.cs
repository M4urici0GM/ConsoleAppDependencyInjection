using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            ServiceProvider serviceProvider = ConfigureServices().BuildServiceProvider();

            serviceProvider.GetService<ILogger<Program>>()
                .LogDebug("Application Starting");
                
            serviceProvider.GetRequiredService<Startup>().Run();

            await serviceProvider.DisposeAsync();
            Console.ReadKey();
        }

        public static IServiceCollection ConfigureServices()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging(cfg => cfg
                .AddConsole());

            serviceCollection.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug);
            serviceCollection.AddTransient(typeof(Startup));
            
            return serviceCollection;
        }
    }
}