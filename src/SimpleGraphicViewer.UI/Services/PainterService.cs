using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Abstracts;
using SimpleGraphicViewer.UI.Constants;
using SimpleGraphicViewer.UI.Mappers;

namespace SimpleGraphicViewer.UI.Services;

public sealed class PainterService
{
    private readonly IPainterContext _painterContext;

    public PainterService(IPainterContext painterContext)
    {
        _painterContext = painterContext;
    }

    public float DrawPrimitives(Graphics graphics, Size areaSize, int yCorrection, IReadOnlyCollection<PrimitiveBase> primitives)
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
            IPainter painter = _painterContext.GetConcretePainter(primitive.Type);
            painter.Draw(graphics, areaSize, primitive, scaleRatio, yCorrection);
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

        return points;
    }
}