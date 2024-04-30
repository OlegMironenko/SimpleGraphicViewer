using Microsoft.Extensions.DependencyInjection;
using SimpleGraphicViewer.UI.Abstracts;
using SimpleGraphicViewer.UI.Painters;
using SimpleGraphicViewer.UI.Services;

namespace SimpleGraphicViewer.UI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUI(this IServiceCollection services)
    {
        services.AddSingleton<IPainterContext, PainterContext>();
        services.AddSingleton<PainterService>();
        services.AddTransient<MainForm>();

        return services;
    }
}