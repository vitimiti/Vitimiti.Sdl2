using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    [DllImport(LibraryName, EntryPoint = "SDL_free")]
    public static extern void Free(IntPtr memory);
}