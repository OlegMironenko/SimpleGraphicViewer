using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Abstracts;
using SimpleGraphicViewer.UI.Constants;
using SimpleGraphicViewer.UI.Extensions;
using SimpleGraphicViewer.UI.Mappers;
using SimpleGraphicViewer.UI.Services;

namespace SimpleGraphicViewer.UI.Painters;

internal class CirclePainter : IPainter
{
    public void Draw(Graphics graphics, Size areaSize, PrimitiveBase primitive, float scaleRatio, int yCorrection)
    {
        CirclePrimitive? circle = primitive as CirclePrimitive;

        if (circle is null)
        {
            return;
        }

        PrimitiveColor colorDefinition = circle.Color;

        Point center = CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(circle.Center.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2 + yCorrection);
        if (circle.Filled.GetValueOrDefault())
        {
            using SolidBrush brush = new(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel));
            graphics.FillCircle(brush, center.X, center.Y, circle.Radius / scaleRatio);
        }
        else
        {
            using Pen pen = new(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel), GraphicsConstants.DEFAULT_BRUSH_WIDTH);
            graphics.DrawCircle(pen, center.X, center.Y, circle.Radius / scaleRatio);
        }
    }
}