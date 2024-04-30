using SimpleGraphicViewer.Core.Enums;
using SimpleGraphicViewer.Core.Exceptions;
using SimpleGraphicViewer.UI.Abstracts;

namespace SimpleGraphicViewer.UI.Painters;

internal sealed class PainterContext : IPainterContext
{
    private readonly Dictionary<PrimitiveType, IPainter> _painters = new()
    {
        { PrimitiveType.Line, new LinePainter() },
        { PrimitiveType.Circle, new CirclePainter() },
        { PrimitiveType.Triangle, new TrianglePainter() },
    };

    public IPainter GetConcretePainter(PrimitiveType primitiveType)
    {
        if (_painters.TryGetValue(primitiveType, out var painter))
        {
            return painter;
        }

        throw new PrimitivePainterNotImplementedException($"Painter for primitive {primitiveType} is not implemented");
    }
}