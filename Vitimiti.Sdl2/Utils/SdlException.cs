using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vitimiti.Sdl2.Utils;

public class SdlException : ExternalException
{
    public SdlException()
    {
    }

    protected SdlException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SdlException(string? message) : base(message)
    {
    }

    public SdlException(string? message, Exception? inner) : base(message, inner)
    {
    }

    public SdlException(string? message, int errorCode) : base(message, errorCode)
    {
    }
}