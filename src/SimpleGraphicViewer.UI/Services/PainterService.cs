using SimpleGraphicViewer.Core.Enums;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Constants;
using SimpleGraphicViewer.UI.Mappers;
using SimpleGraphicViewer.UI.Painters;

namespace SimpleGraphicViewer.UI.Services;

internal class PainterService
{
    public static float DrawPrimitives(Graphics graphics, Size areaSize, int yCorrection,
        IReadOnlyCollection<PrimitiveBase> primitives)
    {
        if (!primitives.Any())
        {
            return GraphicsConstants.DEFAULT_SCALE_RATIO;
        }

        IEnumerable<Point> allPoints = CollectAllPoints(primitives);

        //todo. Move scale calculation to separate class
        float scaleRatio = CoordinateTransformer.CalculateScaleRatio(areaSize, allPoints);

        foreach (PrimitiveBase primitive in primitives)
        {
            switch (primitive.Type)
            {
                case PrimitiveType.Line:
                {
                    new LinePainter().Draw(graphics, areaSize, primitive, scaleRatio, yCorrection);
                    break;
                }
                case PrimitiveType.Circle:
                {
                    new CirclePainter().Draw(graphics, areaSize, primitive, scaleRatio, yCorrection);
                    break;
                }
                case PrimitiveType.Triangle:
                {
                    new TrianglePainter().Draw(graphics, areaSize, primitive, scaleRatio, yCorrection);
                    break;
                }
            }
        }

        return scaleRatio;
    }

    private static IEnumerable<Point> CollectAllPoints(IReadOnlyCollection<PrimitiveBase> primitives)
    {
        List<Point> points = [];
        
        foreach (PrimitiveBase primitive in primitives)
        {
            points.AddRange(primitive.Points.Select(p => p.ToPoint()));
        }
        
        return primitives.SelectMany(x => x.Points)
            .Select(x => x.ToPoint());
    }
}