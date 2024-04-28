namespace SimpleGraphicViewer.UI.Services
{
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
    }
}
