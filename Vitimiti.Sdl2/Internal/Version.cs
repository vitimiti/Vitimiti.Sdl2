using System.Runtime.InteropServices;

using Vitimiti.Sdl2.CustomMarshalers;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Version
    {
        public readonly byte Major;
        public readonly byte Minor;
        public readonly byte Patch;
    }

    [DllImport(LibraryName, EntryPoint = "SDL_GetVersion")]
    public static extern void GetVersion(out Version version);

    [DllImport(LibraryName, EntryPoint = "SDL_GetRevision", CharSet = CharSet.Unicode)]
    [return: MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(SdlStringCustomMarshaler),
        MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetRevision();

    [DllImport(LibraryName, EntryPoint = "SDL_GetRevisionNumber")]
    public static extern int GetRevisionNumber();
}