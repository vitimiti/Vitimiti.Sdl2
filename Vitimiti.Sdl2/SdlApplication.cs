using System.Diagnostics.CodeAnalysis;

using Vitimiti.Sdl2.Internal;
using Vitimiti.Sdl2.Utils;

namespace Vitimiti.Sdl2;

/// <summary>The SDL application, necessary for systems management.</summary>
/// <remarks>
///     <para>
///         Any code that requires any of the <see cref="Subsystems" /> to be active will require this
///         application to be running.
///     </para>
///     <para>This is a disposable class and should be used as such.</para>
/// </remarks>
public sealed class SdlApplication : IDisposable
{
    /// <summary>The SDL version.</summary>
    /// <value>A <see cref="Version" /> containing the SDL version.</value>
    public static Version SdlVersion
    {
        get
        {
            Sdl.GetVersion(out var version);
            return new Version(version.Major, version.Minor, version.Patch);
        }
    }

    /// <summary>The SDL revision.</summary>
    /// <returns>A <see cref="string" /> containing the SDL revision.</returns>
    public static string Revision => Sdl.GetRevision();

    /// <summary>Deprecated, use <see cref="Revision" /> instead.</summary>
    /// <remarks>This used to return a not very reliable revision number from mercurial.</remarks>
    /// <returns>Always returns 0.</returns>
    [Obsolete("Use Revision instead.", false)]
    public static int RevisionNumber => Sdl.GetRevisionNumber();

    /// <summary>The <see cref="Subsystems" /> that have been initialized.</summary>
    /// <returns>
    ///     An <see cref="Enum" /> flags with the initialized <see cref="Subsystems" />.
    /// </returns>
    public static Subsystems InitializedSubsystems => Sdl.WasInit(Subsystems.Everything);

    /// <summary>The SDL application constructor.</summary>
    /// <param name="subsystems">The <see cref="Subsystems" /> to initialize.</param>
    /// <exception cref="SdlException">
    ///     When SDL fails to initialize the given <paramref name="subsystems" />.
    /// </exception>
    public SdlApplication(Subsystems subsystems)
    {
        var errorCode = Sdl.Init(subsystems);
        if (errorCode < 0)
        {
            throw new SdlException(Sdl.GetError(), errorCode);
        }
    }

    private static void ReleaseUnmanagedResources()
    {
        Sdl.Quit();
    }

    /// <summary>Allows the disposal of unmanaged resources.</summary>
    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    /// <summary>The class destructor.</summary>
    /// <remarks>Use the disposing pattern or <see cref="Dispose" />.</remarks>
    ~SdlApplication()
    {
        ReleaseUnmanagedResources();
    }

    /// <summary>Add new <see cref="Subsystems" /> after initializing the <see cref="SdlApplication" />.</summary>
    /// <param name="subsystems">The <see cref="Subsystems"/> to initialize.</param>
    /// <exception cref="SdlException">
    ///     When SDL is unable to initialize the given <paramref name="subsystems"/>.
    /// </exception>
    [SuppressMessage(
        "Performance",
        "CA1822",
        Justification = "Avoid SDL native leaks by forcing IDisposable class.")]
    [SuppressMessage(
        "ReSharper",
        "MemberCanBeMadeStatic.Global",
        Justification = "Avoid SDL native leaks by forcing IDisposable class.")]
    public void AddSubsystems(Subsystems subsystems)
    {
        var errorCode = Sdl.InitSubsystem(subsystems);
        if (errorCode < 0)
        {
            throw new SdlException(Sdl.GetError(), errorCode);
        }
    }

    /// <summary>
    ///     Stop running <see cref="Subsystems" /> after initializing the <see cref="SdlApplication" />.
    /// </summary>
    /// <param name="subsystems">The <see cref="Subsystems"/> to stop.</param>
    [SuppressMessage(
        "Performance",
        "CA1822",
        Justification = "Avoid SDL native leaks by forcing IDisposable class.")]
    [SuppressMessage(
        "ReSharper",
        "MemberCanBeMadeStatic.Global",
        Justification = "Avoid SDL native leaks by forcing IDisposable class.")]
    public void StopSubsystems(Subsystems subsystems)
    {
        Sdl.QuitSubsystem(subsystems);
    }
}