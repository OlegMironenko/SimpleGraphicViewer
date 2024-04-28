namespace SimpleGraphicViewer.Core.Exceptions;

public class UnsupportedSourceFileException : Exception
{
    private const string DEFAULT_MESSAGE = "Unsupported source file type";

    public UnsupportedSourceFileException() : base(DEFAULT_MESSAGE)
    {
    }

    public UnsupportedSourceFileException(string? message) : base(message)
    {
    }

    public UnsupportedSourceFileException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}