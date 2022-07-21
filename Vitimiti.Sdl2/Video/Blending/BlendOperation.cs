namespace Vitimiti.Sdl2.Video.Blending;

/// <summary>The blend operation used when combining source and destination pixel components</summary>
public enum BlendOperation
{
    /// <summary>dst + src</summary>
    /// <remarks>Supported by all renderers.</remarks>
    Add = 0x1,
    
    /// <summary>dst - src</summary>
    /// <remarks>Supported by D3D9, D3D11, OpenGL, OpenGLES.</remarks>
    Subtract = 0x2,
    
    /// <summary>src - dst</summary>
    /// <remarks>Supported by D3D9, D3D11, OpenGL, OpenGLES.</remarks>
    ReverseSubtract = 0x3,
    
    /// <summary>min(dst, src)</summary>
    /// <remarks>Supported by D3D9, D3D11.</remarks>
    Minimum = 0x4,
    
    /// <summary>max(dst, src)</summary>
    /// <remarks>Supported by D3D9, D3D11.</remarks>
    Maximum = 0x5
}