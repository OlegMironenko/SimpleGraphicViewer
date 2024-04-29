using SimpleGraphicViewer.Core.Converters;
using SimpleGraphicViewer.Core.Models.Abstracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleGraphicViewer.Core.Models;

public sealed class TrianglePrimitive : PrimitiveBase
{
    public override PrimitiveBase FromJsonString(string jsonString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(jsonString);

        try
        {
            return JsonSerializer.Deserialize<TrianglePrimitive>(jsonString) ?? new TrianglePrimitive();
        }
        catch (JsonException)
        {
            return new TrianglePrimitive();
        }
    }

    [JsonPropertyName("a")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? PointA { get; set; }
    [JsonPropertyName("b")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? PointB { get; set; }
    [JsonPropertyName("c")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? PointC { get; set; }
}
