using SimpleGraphicViewer.Core.Converters;
using SimpleGraphicViewer.Core.Models.Abstracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleGraphicViewer.Core.Models;

public sealed class LinePrimitive : PrimitiveBase
{
    public override PrimitiveBase FromJsonString(string jsonString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(jsonString);

        try
        {
            return JsonSerializer.Deserialize<LinePrimitive>(jsonString) ?? new LinePrimitive();
        }
        catch (JsonException)
        {
            return new LinePrimitive();
        }
    }

    [JsonPropertyName("a")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? PointA { get; set; }
    [JsonPropertyName("b")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? PointB { get; set; }
}
