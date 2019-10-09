using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    public class Startup
    {

        private ILogger<Startup> Logger { get; set; }
        
        public Startup(ILogger<Startup> logger)
        {
            Logger = logger;
        }
        
        public void Run()
        {
            Logger.LogInformation("Hello world from Startup class using Dependency Injection");
        }
    }
}