using SimpleGraphicViewer.Core.Enums;

namespace SimpleGraphicViewer.UI.Abstracts;

public interface IPainterContext
{
    IPainter GetConcretePainter(PrimitiveType primitiveType);
}