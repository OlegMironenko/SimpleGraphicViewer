using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Abstracts;
using SimpleGraphicViewer.UI.Constants;
using SimpleGraphicViewer.UI.Mappers;
using SimpleGraphicViewer.UI.Services;

namespace SimpleGraphicViewer.UI.Painters;

internal class LinePainter : IPainter
{
    public void Draw(Graphics graphics, Size areaSize, PrimitiveBase primitive, float scaleRatio)
    {
        LinePrimitive? line = primitive as LinePrimitive;

        if (line is null)
        {
            return;
        }

        PrimitiveColor colorDefinition = line.Color;
        using Pen pen = new(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel), GraphicsConstants.DEFAULT_BRUSH_WIDTH);

        graphics.DrawLine(pen
            , CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(line.PointA.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2)
            , CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(line.PointB.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2));
    }
}