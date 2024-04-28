using SimpleGraphicViewer.Core.Enums;
using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using System.Text.Json.Nodes;
using SimpleGraphicViewer.Core.Abstracts;

namespace SimpleGraphicViewer.Infrastructure.Parsers;

internal class JsonSourceFileParser : ISourceFileParser
{
    public IEnumerable<PrimitiveBase> Parse(string jsonData)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(jsonData);

        JsonArray? nodes = JsonNode.Parse(jsonData)?.AsArray();

        if (nodes is null or { Count: 0 })
        {
            return Empty;
        }

        List<PrimitiveBase> primitives = [];
        foreach (JsonNode? jsonNode in nodes)
        {
            if (jsonNode is null)
            {
                continue;
            }

            string? type = jsonNode["type"]?.ToString();

            if (string.IsNullOrEmpty(type))
            {
                continue;
            }

            PrimitiveBase? primitive = ParsePrimitive(jsonNode, type);

            if (primitive is not null)
            {
                primitives.Add(primitive);
            }
        }

        return primitives;
    }

    private static PrimitiveBase? ParsePrimitive(JsonNode jsonNode, string type)
    {
        PrimitiveType primitiveType = (PrimitiveType)Enum.Parse(typeof(PrimitiveType), type, ignoreCase: true);

        PrimitiveBase? primitive = primitiveType switch
        {
            PrimitiveType.Line => new LinePrimitive().FromJsonString(jsonNode.ToJsonString()),
            PrimitiveType.Circle => new CirclePrimitive().FromJsonString(jsonNode.ToJsonString()),
            PrimitiveType.Triangle => new TrianglePrimitive().FromJsonString(jsonNode.ToJsonString()),
            _ => default
        };

        return primitive;
    }

    private static IEnumerable<PrimitiveBase> Empty => [];
}
