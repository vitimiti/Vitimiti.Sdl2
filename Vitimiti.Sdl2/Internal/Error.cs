using System.Runtime.InteropServices;

using Vitimiti.Sdl2.CustomMarshalers;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    [DllImport(LibraryName, EntryPoint = "SDL_GetError", CharSet = CharSet.Unicode)]
    [return: MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(SdlStringCustomMarshaler),
        MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetError();
}