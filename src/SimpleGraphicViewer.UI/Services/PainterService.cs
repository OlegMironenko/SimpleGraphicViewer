using SimpleGraphicViewer.Core.Enums;
using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Constants;
using SimpleGraphicViewer.UI.Mappers;
using SimpleGraphicViewer.UI.Painters;

namespace SimpleGraphicViewer.UI.Services;

internal class PainterService
{
    public static float DrawPrimitives(Graphics graphics, Size areaSize, int yCorrection, IReadOnlyCollection<PrimitiveBase> primitives)
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

        //todo. Move array of points to in-memory cache, this allows to skip this step when window is resized
        //todo. Cache should be invalidated after new file is loaded
        foreach (PrimitiveBase primitive in primitives)
        {
            switch (primitive.Type)
            {
                case PrimitiveType.Line:
                {
                    LinePrimitive? line = primitive as LinePrimitive;
                    if (line is not null)
                    {
                        points.Add(line.PointA.ToPoint());
                        points.Add(line.PointB.ToPoint());
                    }

                    break;
                }
                case PrimitiveType.Circle:
                {
                    CirclePrimitive? circle = primitive as CirclePrimitive;
                    if (circle is not null) 
                    {
                        points.Add(new Point((int)(circle.Center.PointX - circle.Radius), (int)circle.Center.PointY));
                        points.Add(new Point((int)circle.Center.PointX, (int)(circle.Center.PointY + circle.Radius)));
                        points.Add(new Point((int)(circle.Center.PointX + circle.Radius), (int)circle.Center.PointY));
                        points.Add(new Point((int)circle.Center.PointX, (int)(circle.Center.PointY - circle.Radius)));
                    }

                    break;
                }
                case PrimitiveType.Triangle:
                {
                    TrianglePrimitive? triangle = primitive as TrianglePrimitive;
                    if (triangle is not null)
                    {
                        points.Add(triangle.PointA.ToPoint());
                        points.Add(triangle.PointB.ToPoint());
                        points.Add(triangle.PointC.ToPoint());
                    }

                    break;
                }
            }
        }

        return points;
    }
}