using Microsoft.Extensions.DependencyInjection;
using SimpleGraphicViewer.Core.Parsers;
using SimpleGraphicViewer.Infrastructure.Parsers;

namespace SimpleGraphicViewer.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddKeyedTransient<IPrimitiveParser, JsonPrimitivesParser>("JsonParser");
        }
    }
}
