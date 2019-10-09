using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    public class Startup
    {

        private ILogger<Startup> Logger { get; set; }
        
        //Here is a clearly example of Dependency Injection
        //I'm telling to the service collection to this class works, it needs the ILogger service of type Startup
        public Startup(ILogger<Startup> logger)
        {
            Logger = logger;
        }
        
        public void Run()
        {
            //Calling the Logger service injected using Dependency Injection.
            Logger.LogInformation("Hello world from Startup class using Dependency Injection");
        }
    }
}