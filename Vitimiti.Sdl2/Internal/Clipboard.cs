using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using Vitimiti.Sdl2.CustomMarshalers;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    [SuppressMessage("Globalization", "CA2101", Justification = "Charset cannot be set here.")]
    [DllImport(LibraryName, EntryPoint = "SDL_SetClipboardText")]
    public static extern int SetClipboardText(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SdlStringCustomMarshaler))]
        string text);

    [DllImport(LibraryName, EntryPoint = "SDL_GetClipboardText", CharSet = CharSet.Unicode)]
    [return: MarshalAs(
        UnmanagedType.CustomMarshaler,
        MarshalTypeRef = typeof(SdlStringCustomMarshaler),
        MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetClipboardText();

    [DllImport(LibraryName, EntryPoint = "SDL_HasClipboardText")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasClipboardText();
}