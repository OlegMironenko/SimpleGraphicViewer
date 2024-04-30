using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Abstracts;
using SimpleGraphicViewer.UI.Mappers;
using SimpleGraphicViewer.UI.Services;

namespace SimpleGraphicViewer.UI.Painters;

internal sealed class TrianglePainter : IPainter
{
    public void Draw(Graphics graphics, Size areaSize, PrimitiveBase primitive, float scaleRatio, int yCorrection)
    {
        TrianglePrimitive? triangle = primitive as TrianglePrimitive;

        if (triangle is null)
        {
            return;
        }

        PrimitiveColor colorDefinition = triangle.Color;
        Point[] vertices =
        [
            CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(triangle.PointA.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2 + yCorrection),
            CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(triangle.PointB.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2 + yCorrection),
            CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(triangle.PointC.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2 + yCorrection)
        ];

        if (triangle.Filled.GetValueOrDefault())
        {
            using SolidBrush brush = new(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel));
            graphics.FillPolygon(brush, vertices);
        }
        else
        {
            using Pen pen = new(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel), 1);
            graphics.DrawPolygon(pen, vertices);
        }
    }
}