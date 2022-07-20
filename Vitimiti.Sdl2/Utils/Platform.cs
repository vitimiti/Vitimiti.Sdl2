using Vitimiti.Sdl2.Internal;

namespace Vitimiti.Sdl2.Utils;

/// <summary>Get platform information.</summary>
public static class Platform
{
    /// <summary>Get the platform name.</summary>
    public static string Name => Sdl.GetPlatform();
}