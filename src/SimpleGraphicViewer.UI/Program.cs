using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleGraphicViewer.Infrastructure.Extensions;

namespace SimpleGraphicViewer.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        IHost host = CreateHostBuilder().Build();
        Application.Run(host.Services.GetRequiredService<MainForm>());
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddInfrastructure();
                services.AddTransient<MainForm>();
            });
    }
}