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

            //Here i'm getting the already injected ILogger service and logging a debug message
            //to inform the application is starting
            serviceProvider.GetService<ILogger<Program>>()
                .LogDebug("Application Starting");
              
            //Running the main method of the application, which is located in the Startup class
            serviceProvider.GetRequiredService<Startup>().Run();

            //Disposing the services, 'cause at this point we do not need them anymore.
            await serviceProvider.DisposeAsync();
            Console.ReadKey();
        }

        public static IServiceCollection ConfigureServices()
        {
            //Create a new instance of Service Collection
            ServiceCollection serviceCollection = new ServiceCollection();

            //Adding a new Logging provider, in that case, a Console one.
            serviceCollection.AddLogging(cfg => cfg
                .AddConsole());
            //Here i'm saying to the LoggerFilter to set the minimum level of logging to Debug
            //It means that everything that is lower than debug will not appear in the console.
            serviceCollection.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug);
            
            //And here is the trick:
            //I'm creating an instance of my main application class (Startup) and injecting it in the services.
            serviceCollection.AddTransient(typeof(Startup));
            
            return serviceCollection;
        }
    }
}