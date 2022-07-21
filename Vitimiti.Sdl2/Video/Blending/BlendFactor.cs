namespace Vitimiti.Sdl2.Video.Blending;

/// <summary>The normalized factor used to multiply pixel components.</summary>
public enum BlendFactor
{
    /// <summary>R:0, G:0, B:0, A:0</summary>
    Zero = 0x1,
    
    /// <summary>R:1, G:1, B:1, A:1</summary>
    One = 0x2,
    
    /// <summary>R:srcR, G:srcG, B:srcB, A:srcA</summary>
    SourceColor = 0x3,
    
    /// <summary>R:1 - srcR, G:1 - srcG, B:1 - srcB, A:1 - srcA</summary>
    OneMinusSourceColor = 0x4,
    
    /// <summary>R:srcA, G:srcA, B:srcA, A:srcA</summary>
    SourceAlpha = 0x5,
    
    /// <summary>R:1 - srcA, G:1 - srcA, B:1 - srcA, A:1 - srcA</summary>
    OneMinusSourceAlpha = 0x6,
    
    /// <summary>R:dstR, G:dstG, B:dstB, A:dstA</summary>
    DestinationColor = 0x7,
    
    /// <summary>R:1 - dstR, G:1 - dstG, B:1 - dstB, A:1 - dstA</summary>
    OneMinusDestinationColor = 0x8,
    
    /// <summary>R:dstA, G:dstA, B:dstB, A:dstA</summary>
    DestinationAlpha = 0x9,
    
    /// <summary>R:1 - dstA, G:1 - dstA, B:1 - dstB, A:1 - dstA</summary>
    OneMinusDestinationAlpha = 0xA
}