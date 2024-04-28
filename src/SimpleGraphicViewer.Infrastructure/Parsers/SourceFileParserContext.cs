using SimpleGraphicViewer.Core.Abstracts;
using SimpleGraphicViewer.Core.Constants;
using SimpleGraphicViewer.Core.Exceptions;

namespace SimpleGraphicViewer.Infrastructure.Parsers;

internal class SourceFileParserContext : ISourceFileParserContext
{
    private readonly Dictionary<string, ISourceFileParser> _parsers = new(StringComparer.OrdinalIgnoreCase)
    {
        { AllowedFileExtensions.JSON, new JsonSourceFileParser() }
    };

    public ISourceFileParser GetConcreteParser(string extension)
    {
        if (_parsers.TryGetValue(extension, out var parser))
        {
            return parser;
        }

        throw new UnsupportedSourceFileException();
    }
}