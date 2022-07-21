namespace Vitimiti.Sdl2.Video.Blending;

// TODO: Change SDL_RenderCopy for our function.
/// <summary>The blend mode used in SDL_RenderCopy() and drawing operations.</summary>
public enum BlendMode
{
    /// <summary>No blending.</summary>
    /// <remarks><c>dstRGBA = srcRGBA</c></remarks>
    None = 0x00000000,
    
    /// <summary>Alpha blending.</summary>
    /// <remarks>
    ///   <code>
    ///     dstRGB = (srcRGB * srcA) + (dstRGB * (1 - srcA))
    ///     dstA = srcA + (dstA * (1 - srcA))
    ///   </code>
    /// </remarks>
    Blend = 0x00000001,
    
    /// <summary>Additive blending.</summary>
    /// <remarks>
    ///   <code>
    ///     dstRGB = (srcRGB * srcA) + dstRGB
    ///     dstA = dstA
    ///   </code>
    /// </remarks>
    Add = 0x00000002,
    
    /// <summary>Color modulate.</summary>
    /// <remarks>
    ///   <code>
    ///     dstRGB = srcRGB * dstRGB
    ///     dstA = dstA
    ///   </code>
    /// </remarks>
    Modulate = 0x00000004,
    
    /// <summary>Color multiply.</summary>
    /// <remarks>
    ///   <code>
    ///     dstRGB = (srcRGB * dstRGB) + (dstRGB * (1 - srcA))
    ///     dstA = (srcA * dstA) + (dstA * (1 - srcA))
    ///   </code>
    /// </remarks>
    Multiply = 0x00000008,
    
    /// <summary>Invalid blend mode.</summary>
    Invalid = 0x7FFFFFFF
}