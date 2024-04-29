using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
using SimpleGraphicViewer.Core.Models;

namespace SimpleGraphicViewer.Core.Converters;

public class PrimitivePointJsonConverter : JsonConverter<PrimitivePoint>
{
    private const char COORDINATES_SEPARATOR = ';';
    private const int SEGMENTS_COUNT = 2;

    public override PrimitivePoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string[] pointRow = reader.GetString()!.Split(COORDINATES_SEPARATOR);

        if (pointRow.Length != SEGMENTS_COUNT)
        {
            return default;
        }

        //todo. Discuss culture, what is the fractional part separator
        CultureInfo culture = new("de-DE");

        if (float.TryParse(pointRow[0], NumberStyle, culture, out float x)
            && float.TryParse(pointRow[1], NumberStyle, culture, out float y))
        {
            return new PrimitivePoint(x, y);
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, PrimitivePoint value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.PointX}{COORDINATES_SEPARATOR} {value.PointY}");
    }
    
    private static NumberStyles NumberStyle => NumberStyles.AllowLeadingWhite | NumberStyles.Any;
}
