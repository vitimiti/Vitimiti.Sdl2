namespace Vitimiti.Sdl2;

/// <summary>The SDL subsystem flags.</summary>
/// <remarks>These flags can be combined and are used in <see cref="SdlApplication" /></remarks>
/// <seealso cref="SdlApplication(Subsystems)" />
/// <seealso cref="SdlApplication.AddSubsystems" />
/// <seealso cref="SdlApplication.StopSubsystems" />
[Flags]
public enum Subsystems : uint
{
    /// <summary>No subsystems.</summary>
    None = 0x00000000U,

    /// <summary>Timer subsystem.</summary>
    Timer = 0x00000001U,

    /// <summary>Audio subsystem.</summary>
    Audio = 0x00000010U,

    /// <summary>Video subsystem.</summary>
    /// <remarks>This subsystem implies the <see cref="Events" /> subsystem.</remarks>
    Video = 0x00000020U,

    /// <summary>Joystick subsystem.</summary>
    /// <remarks>This subsystem implies the <see cref="Events" /> subsystem.</remarks>
    Joystick = 0x00000200U,

    /// <summary>Haptic subsystem.</summary>
    Haptic = 0x00001000U,

    /// <summary>Game controller subsystem.</summary>
    /// <remarks>
    ///     This subsystem implies the <see cref="Events" /> and <see cref="Joystick" /> subsystems.
    /// </remarks>
    GameController = 0x00002000U,

    /// <summary>The events subsystem.</summary>
    Events = 0x00004000U,

    /// <summary>The sensor subsystem.</summary>
    /// <remarks>This subsystem implies the <see cref="Events" /> subsystem.</remarks>
    Sensor = 0x00008000U,

    /// <summary>Deprecated, will be ignored.</summary>
    /// <remarks>This subsystem used to allow SDL to ignore fatal signals.</remarks>
    [Obsolete("For compatibility, this flag is ignored.", false)]
    NoParachute = 0x00100000U,

    /// <summary>Initialized all subsystems.</summary>
    Everything = Timer
        | Audio
        | Video
        | Joystick
        | Haptic
        | GameController
        | Events
        | Sensor
}