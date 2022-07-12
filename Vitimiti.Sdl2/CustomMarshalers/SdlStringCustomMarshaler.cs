using System.Runtime.InteropServices;

using Vitimiti.Sdl2.Internal;

namespace Vitimiti.Sdl2.CustomMarshalers;

internal sealed class SdlStringCustomMarshaler : ICustomMarshaler
{
    private static ICustomMarshaler? s_allocatedInstance;
    private static ICustomMarshaler? s_defaultInstance;

    private readonly bool _allocatedInstance;

    public const string LeaveAllocatedCookie = "LeaveAllocated";

    public static ICustomMarshaler GetInstance(string cookie)
    {
        return cookie switch
        {
            LeaveAllocatedCookie => s_allocatedInstance ??= new SdlStringCustomMarshaler(true),
            _ => s_defaultInstance ??= new SdlStringCustomMarshaler(false)
        };
    }

    private SdlStringCustomMarshaler(bool allocatedInstance)
    {
        _allocatedInstance = allocatedInstance;
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public void CleanUpNativeData(IntPtr nativeData)
    {
        if (!_allocatedInstance)
        {
            Sdl.Free(nativeData);
        }
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public IntPtr MarshalManagedToNative(object managedObj)
    {
        return managedObj is not string str
            ? throw new ArgumentException(
                $"{nameof(managedObj)} is not of type {typeof(string)}, but instead was of type {managedObj.GetType()}")
            : Marshal.StringToCoTaskMemUTF8(str);
    }

    public object MarshalNativeToManaged(IntPtr nativeData)
    {
        return Marshal.PtrToStringUTF8(nativeData) ?? string.Empty;
    }
}