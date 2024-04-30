using SimpleGraphicViewer.Core.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleGraphicViewer.Core.Converters;

public sealed class PrimitiveColorJsonConverter : JsonConverter<PrimitiveColor>
{
    private const char CHANNELS_SEPARATOR = ';';
    private const int SEGMENTS_COUNT = 4;

    public override PrimitiveColor? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string[] colorRow = reader.GetString()!.Split(CHANNELS_SEPARATOR);

        if (colorRow.Length != SEGMENTS_COUNT)
        {
            return default;
        }

        if (byte.TryParse(colorRow[0], out byte alphaChannel)
            && byte.TryParse(colorRow[1], out byte redChannel)
            && byte.TryParse(colorRow[2], out byte greenChannel)
            && byte.TryParse(colorRow[3], out byte blueChannel))
        {
            return new PrimitiveColor(alphaChannel, redChannel, greenChannel, blueChannel);
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, PrimitiveColor value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.AlphaChannel}{CHANNELS_SEPARATOR} {value.RedChannel}{CHANNELS_SEPARATOR} {value.GreenChannel}{CHANNELS_SEPARATOR} {value.BlueChannel}");
    }
}
