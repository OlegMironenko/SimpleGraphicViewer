using Microsoft.Extensions.DependencyInjection;
using SimpleGraphicViewer.Core.Abstracts;
using SimpleGraphicViewer.Infrastructure.Parsers;

namespace SimpleGraphicViewer.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ISourceFileParserContext, SourceFileParserContext>();

        return services;
    }
}
