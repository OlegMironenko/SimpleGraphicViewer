namespace SimpleGraphicViewer.UI.Services;

internal static class CoordinateTransformer
{
    public static Point ShiftActual(Point point, int xOffset, int yOffset)
    {
        return new Point(point.X + xOffset, yOffset - point.Y);
    }

    public static Point ShiftDisplayed(Point point, int xOffset, int yOffset)
    {
        return new Point(point.X - xOffset, yOffset - point.Y);
    }

    public static Point Scale(Point point, float scaleRatio) 
    {
        return new Point((int)(point.X / scaleRatio), (int)(point.Y / scaleRatio));
    }

    public static float CalculateScaleRatio(Size drawAreaSize, IEnumerable<Point> points)
    {
        int thresholdX = drawAreaSize.Width / 2;
        int thresholdY = drawAreaSize.Height / 2;

        int absoluteMaxX = thresholdX;
        int absoluteMaxY = thresholdY;

        foreach (Point point in points)
        {
            if (Math.Abs(point.X) > absoluteMaxX)
            {
                absoluteMaxX = Math.Abs(point.X);
            }
            if (Math.Abs(point.Y) > absoluteMaxY)
            {
                absoluteMaxY = Math.Abs(point.Y);
            }
        }

        return Math.Max((float)absoluteMaxX / thresholdX, (float)absoluteMaxY / thresholdY);
    }
}
