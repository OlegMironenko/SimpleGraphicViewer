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

    public override IEnumerable<PrimitivePoint> Points =>
    [
        new PrimitivePoint(Center.PointX - Radius, Center.PointY),
        new PrimitivePoint(Center.PointX, Center.PointY + Radius),
        new PrimitivePoint(Center.PointX + Radius, Center.PointY),
        new PrimitivePoint(Center.PointX, Center.PointY - Radius)
    ];

    [JsonPropertyName("center")]
    [JsonConverter(typeof(PrimitivePointJsonConverter))]
    public PrimitivePoint? Center { get; set; }

    [JsonPropertyName("radius")] public float Radius { get; set; }
}