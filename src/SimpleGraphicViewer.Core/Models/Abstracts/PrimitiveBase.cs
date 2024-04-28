using SimpleGraphicViewer.Core.Converters;
using SimpleGraphicViewer.Core.Enums;
using System.Text.Json.Serialization;

namespace SimpleGraphicViewer.Core.Models.Abstracts;

public abstract class PrimitiveBase
{
    public abstract PrimitiveBase FromJsonString(string jsonString);

    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PrimitiveType Type { get; set; }
    [JsonPropertyName("filled")]
    public bool? Filled { get; set; }
    [JsonPropertyName("color")]
    [JsonConverter(typeof(PrimitiveColorJsonConverter))]
    public PrimitiveColor? Color { get; set; }
}
