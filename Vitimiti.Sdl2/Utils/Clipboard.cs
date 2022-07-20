using Vitimiti.Sdl2.Internal;

namespace Vitimiti.Sdl2.Utils;

/// <summary>A class to manage the SDL clipboard.</summary>
public static class Clipboard
{
    /// <summary>Get/Set the clipboard text.</summary>
    /// <exception cref="SdlException">When SDL is unable to set the clipboard text.</exception>
    public static string Text
    {
        get => Sdl.GetClipboardText();
        set
        {
            var errorCode = Sdl.SetClipboardText(value);
            if (errorCode < 0)
            {
                throw new SdlException(Sdl.GetError(), errorCode);
            }
        }
    }

    /// <summary>Whether the clipboard has text or not.</summary>
    public static bool HasText => Sdl.HasClipboardText();
}