namespace SimpleGraphicViewer.Core.Exceptions;

public class PrimitivePainterNotImplementedException : Exception
{
    private const string DEFAULT_MESSAGE = "Painter not implemented";

    public PrimitivePainterNotImplementedException() : base(DEFAULT_MESSAGE)
    {
    }

    public PrimitivePainterNotImplementedException(string? message) : base(message)
    {
    }

    public PrimitivePainterNotImplementedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}