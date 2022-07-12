using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2.Internal;

internal static partial class Sdl
{
    public const string LibraryName = "SDL2";

    [DllImport(LibraryName, EntryPoint = "SDL_Init")]
    public static extern int Init(Subsystems flags);

    [DllImport(LibraryName, EntryPoint = "SDL_InitSubSystem")]
    public static extern int InitSubsystem(Subsystems flags);

    [DllImport(LibraryName, EntryPoint = "SDL_QuitSubSystem")]
    public static extern void QuitSubsystem(Subsystems flags);

    [DllImport(LibraryName, EntryPoint = "SDL_WasInit")]
    public static extern Subsystems WasInit(Subsystems flags);

    [DllImport(LibraryName, EntryPoint = "SDL_Quit")]
    public static extern void Quit();
}