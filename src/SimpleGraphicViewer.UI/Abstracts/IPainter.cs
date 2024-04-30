using SimpleGraphicViewer.Core.Models.Abstracts;

namespace SimpleGraphicViewer.UI.Abstracts;

public interface IPainter
{
    public void Draw(Graphics graphics, Size areaSize, PrimitiveBase primitive, float scaleRatio, int yCorrection);
}