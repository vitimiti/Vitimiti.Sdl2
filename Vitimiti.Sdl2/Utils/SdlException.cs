using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vitimiti.Sdl2.Utils;

/// <summary>SDL related exceptions.</summary>
/// <remarks>This exception inherits from <see cref="ExternalException" /></remarks>
public class SdlException : ExternalException
{
    /// <summary>The base constructor, no messages.</summary>
    public SdlException()
    {
    }

    /// <summary>A constructor for serialization.</summary>
    /// <param name="info">Serialization information.</param>
    /// <param name="context">Streaming context.</param>
    public SdlException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    /// <summary>A constructor with just an error message.</summary>
    /// <param name="message">The error message.</param>
    public SdlException(string? message) : base(message)
    {
    }

    /// <summary>A constructor with an error message and an inner exception.</summary>
    /// <param name="message">The error message.</param>
    /// <param name="inner">The inner exception.</param>
    public SdlException(string? message, Exception? inner) : base(message, inner)
    {
    }

    /// <summary>A constructor with an error message and an error code.</summary>
    /// <param name="message">The error message.</param>
    /// <param name="errorCode">The error code.</param>
    public SdlException(string? message, int errorCode) : base(message, errorCode)
    {
    }
}