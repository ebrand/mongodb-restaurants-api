using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restaurants.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()

                // use an in-memory web server
                .UseKestrel()

                // set the content root
                .UseContentRoot(Directory.GetCurrentDirectory())

                // app configuration
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    config
                        .AddEnvironmentVariables();
                })

                // logging
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })

                // define the startup class containing methods for configuring the IServiceCollection
                // and the IApplicationBuilder
                .UseStartup<Startup>()

                // Calling the IWebHostBuilder.Build() method below, in-turn calls the 'ConfigureServices()'
                // and 'Configure()' methods of the 'Startup' class defined in the step above.
                .Build();

            // configuration is complete, start the web host...
            webHost.Run();
        }
    }
}