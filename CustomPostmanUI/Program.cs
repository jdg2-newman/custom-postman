using System;
using System.Windows.Forms;
using CustomPostman;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomPostmanUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set up a Host for Dependency Injection
            var host = CreateHostBuilder().Build();

            // Start the application with DI services
            ApplicationConfiguration.Initialize();

            // Resolve the main form (Dashboard) from DI
            var dashboard = host.Services.GetRequiredService<Dashboard>();
            Application.Run(dashboard);
        }

        private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register your services here
                    services.AddSingleton<Dashboard>(); // Register the main form
                    services.AddScoped<IApiAccess, ApiAccess>(); // Example service
                });
    }
}