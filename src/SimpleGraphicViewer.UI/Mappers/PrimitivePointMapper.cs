using SimpleGraphicViewer.Core.Models;

namespace SimpleGraphicViewer.UI.Mappers
{
    public static class PrimitivePointMapper
    {
        public static Point ToPoint(this PrimitivePoint primitivePoint)
        {
            return new Point((int)primitivePoint.PointX, (int)primitivePoint.PointY);
        }
    }
}
