using Vitimiti.Sdl2.Internal;

namespace Vitimiti.Sdl2.Utils;

/// <summary>Basic CPU information.</summary>
public static class CpuInformation
{
    /// <summary>This is a guess for the cacheline size used for padding.</summary>
    public const int GuessedCacheLineSize = 128;

    /// <summary>Get the number of CPU logical cores available.</summary>
    /// <remarks>
    ///   On CPUs that include technologies such as hyperthreading, the number of logical cores may
    ///   be more than the number of physical cores.
    /// </remarks>
    public static int Count => Sdl.GetCpuCount();

    /// <summary>Determine the L1 cache line size of the CPU.</summary>
    /// <remarks>
    ///   This is useful for determining multi-threaded structure padding or SIMD prefetch sizes.
    /// </remarks>
    public static int CacheLineSize => Sdl.GetCpuCacheLineSize();

    /// <summary>Determine whether the CPU has the RDTSC instruction.</summary>
    /// <remarks>
    ///   This always returns false on CPUs that aren't using Intel instruction sets.
    /// </remarks>
    /// <seealso cref="HasRdtsc" />
    /// <seealso cref="Has3DNow" />
    /// <seealso cref="HasAltiVec" />
    /// <seealso cref="HasAvx" />
    /// <seealso cref="HasAvx2" />
    /// <seealso cref="HasAvx512F" />
    /// <seealso cref="HasMmx" />
    /// <seealso cref="HasSse" />
    /// <seealso cref="HasSse2" />
    /// <seealso cref="HasSse3" />
    /// <seealso cref="HasSse41" />
    /// <seealso cref="HasSse42" />
    /// <seealso cref="HasArmSimd" />
    public static bool HasRdtsc => Sdl.HasRdtsc();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has AltiVec features.</summary>
    /// <remarks>
    ///   This always returns false on CPUs that aren't using PowerPC instruction sets.
    /// </remarks>
    public static bool HasAltiVec => Sdl.HasAltiVec();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has MMX features.</summary>
    public static bool HasMmx => Sdl.HasMmx();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has 3DNow! features.</summary>
    /// <remarks>This always returns false on CPUs that aren't using AMD instruction sets.</remarks>
    public static bool Has3DNow => Sdl.Has3DNow();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has SSE features.</summary>
    public static bool HasSse => Sdl.HasSse();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has SSE2 features.</summary>
    public static bool HasSse2 => Sdl.HasSse2();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has SSE3 features.</summary>
    public static bool HasSse3 => Sdl.HasSse3();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has SSE4.1 features.</summary>
    public static bool HasSse41 => Sdl.HasSse41();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has SSE4.2 features.</summary>
    public static bool HasSse42 => Sdl.HasSse42();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has AVX features.</summary>
    public static bool HasAvx => Sdl.HasAvx();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has AVX2 features.</summary>
    public static bool HasAvx2 => Sdl.HasAvx2();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has AVX-512F (foundation) features.</summary>
    public static bool HasAvx512F => Sdl.HasAvx512F();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has ARM SIMD (ARMv6) features.</summary>
    /// <remarks>
    ///   <para>This is different from ARM NEON, which is a different instruction set.</para>
    ///   <para>This always returns false on CPUS that aren't using ARM instruction sets.</para>
    /// </remarks>
    public static bool HasArmSimd => Sdl.HasArmSimd();

    /// <inheritdoc cref="HasRdtsc" />
    /// <summary>Determine whether the CPU has NEON (ARM SIMD) features.</summary>
    /// <remarks>This always returns false on CPUS that aren't using ARM instruction sets.
    /// </remarks>
    public static bool HasNeon => Sdl.HasNeon();

    /// <summary>Get the amount of RAM configured by the system.</summary>
    public static int SystemRam => Sdl.GetSystemRam();
}