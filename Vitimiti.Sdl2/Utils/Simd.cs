using System.Diagnostics.CodeAnalysis;

using Vitimiti.Sdl2.Internal;

namespace Vitimiti.Sdl2.Utils;

/// <summary>A class to manage SIMD memory.</summary>
/// <remarks>This is a disposable class and should be used as such.</remarks>
public sealed class Simd : IDisposable
{
    /// <summary>Report the alignment this system needs for SIMD allocations.</summary>
    /// <remarks>
    ///   This will return the minimum number of bytes to which a pointer must be aligned to be
    ///   compatible with SIMD instructions on the current machine. For example, if the machine
    ///   supports SSE only, it will return 16, but if it supports AVX-512F, it'll return 64 (etc).
    ///   This only reports values for instruction sets SDL knows about, so if your SDL build
    ///   doesn't have <see cref="CpuInformation.HasAvx512F" />, then it might return 16 for the SSE
    ///   support it sees and not 64 for the AVX-512 instructions that exist but SDL doesn't know
    ///   about. Plan accordingly.
    /// </remarks>
    public static uint Alignment => Sdl.SimdGetAlignment();

    /// <summary>Get the native unsafe handle.</summary>
    [SuppressMessage(
        "ReSharper",
        "MemberCanBePrivate.Global",
        Justification = "This is a library, intentional public member.")]
    public IntPtr UnsafeHandle { get; private set; }

    private Simd(IntPtr unsafeHandle)
    {
        UnsafeHandle = unsafeHandle;
        if (UnsafeHandle == IntPtr.Zero)
        {
            throw new SdlException(Sdl.GetError());
        }
    }

    /// <summary>Allocate memory in a SIMD-friendly way.</summary>
    /// <remarks>
    ///   <para>
    ///     This will allocate a block of memory that is suitable for use with SIMD instructions.
    ///     Specifically, it will be properly aligned and padded for the system's supported vector
    ///     instructions.
    ///   </para>
    ///   <para>
    ///     The memory returned will be padded such that it is safe to read or write an incomplete
    ///     vector at the end of the memory block. This can be useful so you don't have to drop back
    ///     to a scalar fallback at the end of your SIMD processing loop to deal with the final
    ///     elements without overflowing the allocated buffer.
    ///   </para>
    ///   <para>
    ///     Note that SDL will only deal with SIMD instruction sets it is aware of; for example,
    ///     SDL 2.0.8 knows that SSE wants 16-byte vectors (<see cref="CpuInformation.HasSse" />),
    ///     and AVX2 wants 32 bytes (<see cref="CpuInformation.HasAvx2" />), but doesn't know that
    ///     AVX-512 wants 64. To be clear: if you can't decide to use an instruction set with an
    ///     <see cref="CpuInformation" /> function, don't use that instruction set with memory
    ///     allocated through here.
    ///   </para>
    ///   <para>
    ///     A <paramref name="length" /> of 0 will create a non <see cref="IntPtr.Zero" />
    ///     <see cref="UnsafeHandle" />, assuming the system isn't out of memory, but you are not
    ///     allowed to dereference it (because you only own zero bytes of that buffer).
    ///   </para>
    /// </remarks>
    /// <param name="length">
    ///   The length, in bytes, of the block to allocate. The actual allocated block might be larger
    ///   due to padding, etc..
    /// </param>
    /// <exception cref="SdlException">
    ///   If SDL is unable to allocate the given memory in a SIMD-friendly way.
    /// </exception>
    /// <seealso cref="Alignment" />
    /// <seealso cref="Reallocate" />
    public Simd(uint length)
    {
        UnsafeHandle = Sdl.SimdAllocate(length);
        if (UnsafeHandle == IntPtr.Zero)
        {
            throw new SdlException(Sdl.GetError());
        }
    }

    private void ReleaseUnmanagedResources()
    {
        if (UnsafeHandle == IntPtr.Zero)
        {
            return;
        }

        Sdl.SimdFree(UnsafeHandle);
        UnsafeHandle = IntPtr.Zero;
    }

    /// <summary>The disposable function.</summary>
    /// <remarks>This function releases the memory in <see cref="UnsafeHandle" />.</remarks>
    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    /// <summary>The destructor.</summary>
    /// <remarks>Use <see cref="Dispose" /> instead.</remarks>
    ~Simd()
    {
        ReleaseUnmanagedResources();
    }

    /// <summary>Reallocate memory from existing one.</summary>
    /// <param name="length">
    ///   The length, in bytes, of the block to be allocated. The actual allocated block might be
    ///   larger due to padding, etc. Passing 0 will create a non <see cref="IntPtr.Zero" />
    ///   <see cref="UnsafeHandle" />, assuming the system isn't out of memory.
    /// </param>
    /// <returns>A newly-reallocated SIMD-friendly block of memory.</returns>
    /// <exception cref="SdlException">
    ///   If SDL is unable to allocate the given memory in a SIMD-friendly way.
    /// </exception>
    public Simd Reallocate(uint length)
    {
        return new Simd(Sdl.SimdReallocate(UnsafeHandle, length));
    }
}