namespace SimpleGraphicViewer.Core.Abstracts;

public interface ISourceFileParserContext
{
    ISourceFileParser GetConcreteParser(string extension);
}