using SimpleGraphicViewer.Core.Models.Abstracts;

namespace SimpleGraphicViewer.Core.Parsers
{
    public interface IPrimitiveParser
    {
        IEnumerable<PrimitiveBase> Parse(string rawData);
    }
}