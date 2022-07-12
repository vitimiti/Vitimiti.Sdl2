using System.Diagnostics.CodeAnalysis;

using Vitimiti.Sdl2.Internal;
using Vitimiti.Sdl2.Utils;

namespace Vitimiti.Sdl2;

public sealed class SdlApplication : IDisposable
{
    private bool _disposedValue;

    public static Version SdlVersion
    {
        get
        {
            Sdl.GetVersion(out var version);
            return new Version(version.Major, version.Minor, version.Patch);
        }
    }

    public static string Revision => Sdl.GetRevision();

    [Obsolete("Use Revision instead.", false)]
    public static int RevisionNumber => Sdl.GetRevisionNumber();
    public static Subsystems InitializedSubsystems => Sdl.WasInit(Subsystems.Everything);

    public SdlApplication(Subsystems subsystems)
    {
        var errorCode = Sdl.Init(subsystems);
        if (errorCode < 0)
        {
            throw new SdlException(Sdl.GetError(), errorCode);
        }
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
            }

            Sdl.Quit();
            _disposedValue = true;
        }
    }

    ~SdlApplication()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    [SuppressMessage(
        "Performance",
        "CA1822",
        Justification = "Avoid SDL native leakes by forcing IDisposable class.")]
    public void AddSubsystems(Subsystems subsystems)
    {
        var errorCode = Sdl.InitSubsystem(subsystems);
        if (errorCode < 0)
        {
            throw new SdlException(Sdl.GetError(), errorCode);
        }
    }

    [SuppressMessage(
        "Performance",
        "CA1822",
        Justification = "Avoid SDL native leakes by forcing IDisposable class.")]
    public void RemoveSubsystems(Subsystems subsystems)
    {
        Sdl.QuitSubsystem(subsystems);
    }
}