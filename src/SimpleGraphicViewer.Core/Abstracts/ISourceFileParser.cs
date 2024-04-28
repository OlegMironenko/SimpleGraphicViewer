using SimpleGraphicViewer.Core.Models.Abstracts;

namespace SimpleGraphicViewer.Core.Abstracts;

public interface ISourceFileParser
{
    IEnumerable<PrimitiveBase> Parse(string rawData);
}