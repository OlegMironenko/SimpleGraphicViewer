using FluentAssertions;
using System.Text;
using System.Text.Json;
using SimpleGraphicViewer.Core.Converters;
using SimpleGraphicViewer.Core.Models;

namespace SimpleGraphicViewer.Core.UnitTests.Converters;

public class PrimitivePointJsonConverterRead
{
    [Theory]
    [InlineData("\"0; 0\"", 0, 0)]
    [InlineData("\"150; 300\"", 150, 300)]
    [InlineData("\"-20; 30\"", -20, 30)]
    [InlineData("\"-1,5; 5,5\"", -1.5, 5.5)]
    public void PassValidPointsString_ReturnsExpectedPoint(string inputJsonString, float expectedX, float expectedY)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(inputJsonString);
        Utf8JsonReader reader = new Utf8JsonReader(bytes);
        reader.Read();
        
        PrimitivePointJsonConverter converter = new();
        PrimitivePoint? result = converter.Read(ref reader, typeof(PrimitivePoint), JsonSerializerOptions.Default);

        result.Should().NotBeNull();
        result.PointX.Should().Be(expectedX);
        result.PointY.Should().Be(expectedY);
    }
    
    [Theory]
    [InlineData("\"0. 0\"")]
    [InlineData("\"0; 0; 0\"")]
    [InlineData("\"0\"")]
    public void PassInValidPointsString_ReturnsNull(string inputJsonString)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(inputJsonString);
        Utf8JsonReader reader = new Utf8JsonReader(bytes);
        reader.Read();
        
        PrimitivePointJsonConverter converter = new();
        PrimitivePoint? result = converter.Read(ref reader, typeof(PrimitivePoint), JsonSerializerOptions.Default);

        result.Should().BeNull();
    }
}