using SimpleGraphicViewer.Core.Enums;
using SimpleGraphicViewer.Core.Models;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.Core.Parsers;
using System.Text.Json.Nodes;

namespace SimpleGraphicViewer.Infrastructure.Parsers
{
    public class JsonPrimitivesParser : IPrimitiveParser
    {
        public IEnumerable<PrimitiveBase> Parse(string jsonData)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(jsonData);

            JsonArray? primitivesArray = JsonNode.Parse(jsonData)?.AsArray();

            if (primitivesArray is null or { Count: 0 })
            {
                return Empty;
            }

            List<PrimitiveBase> primitives = [];
            foreach (var primitive in primitivesArray)
            {
                string type = primitive["type"]?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(type))
                {
                    continue;
                }

                PrimitiveType primitiveType = (PrimitiveType)Enum.Parse(typeof(PrimitiveType), type, ignoreCase: true);

                PrimitiveBase? prim = primitiveType switch
                {
                    PrimitiveType.Line => new LinePrimitive().FromJsonString(primitive.ToJsonString()),
                    PrimitiveType.Circle => new CirclePrimitive().FromJsonString(primitive.ToJsonString()),
                    PrimitiveType.Triangle => new TrianglePrimitive().FromJsonString(primitive.ToJsonString()),
                    _ => default
                };

                if (prim is not null)
                {
                    primitives.Add(prim);
                }
            }

            return primitives;
        }

        private static IEnumerable<PrimitiveBase> Empty => [];
    }
}
