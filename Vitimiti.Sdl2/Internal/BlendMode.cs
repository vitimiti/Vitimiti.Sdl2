using System.Runtime.InteropServices;

using Vitimiti.Sdl2.Video.Blending;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    [DllImport(LibraryName, EntryPoint = "SDL_ComposeCustomBlendMode")]
    public static extern BlendMode ComposeCustomBlendMode(
        BlendFactor srcColorFactor,
        BlendFactor dstColorFactor,
        BlendOperation colorOperation,
        BlendFactor srcAlphaFactor,
        BlendFactor dstAlphaFactor,
        BlendOperation alphaOperation);
}