using SimpleGraphicViewer.Core.Converters;
using SimpleGraphicViewer.Core.Models.Abstracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleGraphicViewer.Core.Models;

public sealed class CirclePrimitive : PrimitiveBase
{
    public override PrimitiveBase FromJsonString(string jsonString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(jsonString);

        try
        {
            return JsonSerializer.Deserialize<CirclePrimitive>(jsonString) ?? new CirclePrimitive();
        }
        catch (JsonException)
        {
            return new CirclePrimitive();
        }
    }

    [JsonPropertyName("center")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? Center { get; set; }
    [JsonPropertyName("radius")]
    public float Radius { get; set; }
}
