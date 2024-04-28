using SimpleGraphicViewer.Core.Enums;
using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Extensions;
using SimpleGraphicViewer.UI.Mappers;

namespace SimpleGraphicViewer.UI.Services
{
    internal class PainterService
    {
        public static float DrawPrimitives(Graphics graphics, Size areaSize, IEnumerable<PrimitiveBase> primitives)
        {
            List<Point> allPoints = [];

            foreach (PrimitiveBase primitive in primitives)
            {
                switch (primitive.Type)
                {
                    case PrimitiveType.Line:
                        {
                            var line = primitive as LinePrimitive;
                            allPoints.Add(line.PointA.ToPoint());
                            allPoints.Add(line.PointB.ToPoint());
                            break;
                        }
                    case PrimitiveType.Circle:
                        {
                            var circle = primitive as CirclePrimitive;
                            allPoints.Add(new Point((int)(circle.Center.PointX - circle.Radius), (int)circle.Center.PointY));
                            allPoints.Add(new Point((int)circle.Center.PointX, (int)(circle.Center.PointY + circle.Radius)));
                            allPoints.Add(new Point((int)(circle.Center.PointX + circle.Radius), (int)circle.Center.PointY));
                            allPoints.Add(new Point((int)circle.Center.PointX, (int)(circle.Center.PointY - circle.Radius)));
                            break;
                        }
                    case PrimitiveType.Triangle:
                        {
                            var triangle = primitive as TrianglePrimitive;
                            allPoints.Add(triangle.PointA.ToPoint());
                            allPoints.Add(triangle.PointB.ToPoint());
                            allPoints.Add(triangle.PointC.ToPoint());
                            break;
                        }
                }
            }

            float scaleRatio = CalculateScaleRatio(areaSize, allPoints);

            foreach (PrimitiveBase primitive in primitives)
            {
                PrimitiveColor colorDefinition = primitive.Color;
                using Pen pen = new Pen(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel), 1);
                using SolidBrush brush = new SolidBrush(Color.FromArgb(colorDefinition.AlphaChannel, colorDefinition.RedChannel, colorDefinition.GreenChannel, colorDefinition.BlueChannel));

                switch (primitive.Type)
                {
                    case PrimitiveType.Line:
                        {
                            var line = primitive as LinePrimitive;

                            graphics.DrawLine(pen
                                , CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(line.PointA.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2)
                                , CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(line.PointB.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2));
                            break;
                        }
                    case PrimitiveType.Circle:
                        {
                            var circle = primitive as CirclePrimitive;
                            Point center = CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(circle.Center.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2);
                            if (circle.Filled.GetValueOrDefault())
                            {
                                graphics.FillCircle(brush, center.X, center.Y, circle.Radius / scaleRatio);
                            }
                            else
                            {
                                graphics.DrawCircle(pen, center.X, center.Y, circle.Radius / scaleRatio);
                            }
                            break;
                        }
                    case PrimitiveType.Triangle:
                        {
                            var triangle = primitive as TrianglePrimitive;
                            Point[] vertices =
                            {
                                CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(triangle.PointA.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2),
                                CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(triangle.PointB.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2),
                                CoordinateTransformer.ShiftActual(CoordinateTransformer.Scale(triangle.PointC.ToPoint(), scaleRatio), areaSize.Width / 2, areaSize.Height / 2)
                            };
                            if (triangle.Filled.GetValueOrDefault())
                            {
                                graphics.FillPolygon(brush, vertices);
                            }
                            else
                            {
                                graphics.DrawPolygon(pen, vertices);
                            }
                            break;
                        }
                }
            }

            return scaleRatio;
        }

        private static float CalculateScaleRatio(Size drawAreaSize, IEnumerable<Point> points)
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
}
