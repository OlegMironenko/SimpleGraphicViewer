using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
using SimpleGraphicViewer.Core.Models;

namespace SimpleGraphicViewer.Core.Converters
{
    public class PrimitivePointJsonConverter : JsonConverter<PrimitivePoint>
    {
        private const char COORDINATES_SEPARATOR = ';';

        public override PrimitivePoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string[] pointRow = reader.GetString()!.Split(COORDINATES_SEPARATOR);

            if (pointRow.Length == 0 || pointRow.Length > 2)
            {
                return default;
            }

            var style = NumberStyles.AllowLeadingWhite | NumberStyles.Any;
            var culture = new CultureInfo("de-DE");

            if (float.TryParse(pointRow[0], style, culture, out float x)
                && float.TryParse(pointRow[1], style, culture, out float y))
            {
                return new PrimitivePoint(x, y);
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, PrimitivePoint value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.PointX}{COORDINATES_SEPARATOR} {value.PointY}");
        }
    }
}
