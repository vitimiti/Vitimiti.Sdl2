using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    [DllImport(LibraryName, EntryPoint = "SDL_GetCPUCount")]
    public static extern int GetCpuCount();

    [DllImport(LibraryName, EntryPoint = "SDL_GetCPUCacheLineSize")]
    public static extern int GetCpuCacheLineSize();

    [DllImport(LibraryName, EntryPoint = "SDL_HasRDTSC")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasRdtsc();

    [DllImport(LibraryName, EntryPoint = "SDL_HasAltiVec")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAltiVec();

    [DllImport(LibraryName, EntryPoint = "SDL_HasMMX")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasMmx();

    [DllImport(LibraryName, EntryPoint = "SDL_Has3DNow")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool Has3DNow();

    [DllImport(LibraryName, EntryPoint = "SDL_HasSSE")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse();

    [DllImport(LibraryName, EntryPoint = "SDL_HasSSE2")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse2();

    [DllImport(LibraryName, EntryPoint = "SDL_HasSSE3")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse3();

    [DllImport(LibraryName, EntryPoint = "SDL_HasSSE41")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse41();

    [DllImport(LibraryName, EntryPoint = "SDL_HasSSE42")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse42();

    [DllImport(LibraryName, EntryPoint = "SDL_HasAVX")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAvx();

    [DllImport(LibraryName, EntryPoint = "SDL_HasAVX2")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAvx2();

    [DllImport(LibraryName, EntryPoint = "SDL_HasAVX512F")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAvx512F();

    [DllImport(LibraryName, EntryPoint = "SDL_HasARMSIMD")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasArmSimd();

    [DllImport(LibraryName, EntryPoint = "SDL_HasNEON")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasNeon();

    [DllImport(LibraryName, EntryPoint = "SDL_GetSystemRAM")]
    public static extern int GetSystemRam();

    [DllImport(LibraryName, EntryPoint = "SDL_SIMDGetAlignment")]
    public static extern uint SimdGetAlignment();

    [DllImport(LibraryName, EntryPoint = "SDL_SIMDAlloc")]
    public static extern IntPtr SimdAllocate(uint length);

    [DllImport(LibraryName, EntryPoint = "SDL_SIMDRealloc")]
    public static extern IntPtr SimdReallocate(IntPtr memory, uint length);

    [DllImport(LibraryName, EntryPoint = "SDL_SIMDFree")]
    public static extern void SimdFree(IntPtr memory);
}