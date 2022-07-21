using Vitimiti.Sdl2.Internal;
using Vitimiti.Sdl2.Utils;

namespace Vitimiti.Sdl2.Video.Blending;

/// <summary>Allows the creation of custom blend modes.</summary>
public static class CustomBlendMode
{
    // TODO: Change native SDL functions to our C# functions.
    /// <summary>Compose a custom blend mode for renderers.</summary>
    /// <remarks>
    ///   <para>
    ///     The functions SDL_SetRenderDrawBlendMode and SDL_SetTextureBlendMode accept the
    ///     <see cref="BlendMode" /> returned by this function if the renderer supports it.
    ///   </para>
    ///   <para>
    ///     A blend mode controls how the pixels from a drawing operation (source) get combined with
    ///     the pixels from the render target (destination). First, the components of the source and
    ///     destination pixels get multiplied with their blend factors. Then, the blend operation
    ///     takes the two products and calculates the result that will get stored in the render
    ///     target.
    ///   </para>
    ///   <para>
    ///     Expressed in pseudocode, it would look like this:
    ///     <code>
    ///       dstRGB = colorOperation(srcRGB * srcColorFactor, dstRGB * dstColorFactor);
    ///       dstA = alphaOperation(srcA * srcAlphaFactor, dstA * dstAlphaFactor);
    ///     </code>
    ///   </para>
    ///   <para>
    ///     Where the functions <c>colorOperation(src, dst)</c> and <c>alphaOperation(src, dst)</c>
    ///     can return one of the following:
    ///     <list type="bullet">
    ///       <item>src + dst</item>
    ///       <item>src - dst</item>
    ///       <item>dst - src</item>
    ///       <item>min(src, dst)</item>
    ///       <item>max(src, dst)</item>
    ///     </list>
    ///   </para>
    ///   <para>
    ///     The red, green, and blue components are always multiplied with the first, second, and
    ///     third components of the <see cref="BlendFactor" />, respectively. The fourth component
    ///     is not used.
    ///   </para>
    ///   <para>
    ///     The alpha component is always multiplied with the fourth component of the
    ///     <see cref="BlendFactor" />. The other components are not used in the alpha calculation.
    ///   </para>
    ///   <para>
    ///     Support for these blend modes varies for each renderer. To check if a specific
    ///     <see cref="BlendMode" /> is supported, create a renderer and pass it to either
    ///     SDL_SetRenderDrawBlendMode or SDL_SetTextureBlendMode. They will return with an error if
    ///     the blend mode is not supported.
    ///   </para>
    ///   <para>
    ///     This list describes the support of custom blend modes for each renderer in SDL 2.0.6.
    ///     All renderers support the four blend modes listed in the <see cref="BlendMode" />
    ///     enumeration.
    ///     <list type="bullet">
    ///       <item>
    ///         <b>Direct3D</b>: Supports all operations with all factors. However, some Supports
    ///         all operations with all factors. However, some <see cref="BlendOperation.Minimum" />
    ///         and <see cref="BlendOperation.Maximum" />.
    ///       </item>
    ///       <item>
    ///         <b>Direct3D11</b>: Supports the <see cref="BlendOperation.Add" /> operation with all
    ///         factors. OpenGL versions 1.1, 1.2, and 1.3 do not work correctly with SDL 2.0.6.
    ///      </item>
    ///       <item>
    ///         <b>OpenGLES</b>: Supports the <see cref="BlendOperation.Add" /> operation with all
    ///         factors. Color and alpha factors need to be the same. OpenGL ES 1 implementation
    ///         specific: May also support <see cref="BlendOperation.Subtract" /> and
    ///         <see cref="BlendOperation.ReverseSubtract" />.  May support color and alpha
    ///         operations being different from each other. May support color and alpha factors
    ///         being different from each other.
    ///       </item>
    ///       <item>
    ///         <b>OpenGLES2</b>: Supports the <see cref="BlendOperation.Add" />,
    ///         <see cref="BlendOperation.Subtract" />,
    ///         <see cref="BlendOperation.ReverseSubtract" /> operations with all factors.
    ///       </item>
    ///       <item><b>PSP</b>: No custom blend mode support.</item>
    ///       <item><b>Software</b>: No custom blend mode support.</item>
    ///     </list>
    ///   </para>
    ///   <para>
    ///     Some renderers do not provide an alpha component for the default render target. The
    ///     <see cref="BlendFactor.DestinationAlpha" /> and
    ///     <see cref="BlendFactor.OneMinusDestinationAlpha" /> factors do not have an effect in
    ///     this case.
    ///   </para>
    /// </remarks>
    /// <param name="srcColorFactor">
    ///   The <see cref="BlendFactor" /> applied to the red, green and blue components of the source
    ///   pixels.
    /// </param>
    /// <param name="dstColorFactor">
    ///   The <see cref="BlendFactor" /> applied to the red, green and blue components of the
    ///   destination pixels.
    /// </param>
    /// <param name="colorOperation">
    ///   The <see cref="BlendOperation" /> used to combine the red, green and blue components of
    ///   the source and destination pixels.
    /// </param>
    /// <param name="srcAlphaFactor">
    ///   The <see cref="BlendFactor" /> applied to the alpha component of the source pixels.
    /// </param>
    /// <param name="dstAlphaFactor">
    ///   The <see cref="BlendFactor" /> applied to the alpha component of the destination pixels.
    /// </param>
    /// <param name="alphaOperation">
    ///   The <see cref="BlendOperation" /> used to combine the alpha component of the source and
    ///   destination pixels.
    /// </param>
    /// <returns>
    ///   The <see cref="BlendMode" /> that represents the chosen factors and operations.
    /// </returns>
    /// <exception cref="SdlException">
    ///   If the <see cref="BlendMode" /> is <see cref="BlendMode.Invalid" />.
    /// </exception>
    public static BlendMode Compose(
        BlendFactor srcColorFactor,
        BlendFactor dstColorFactor,
        BlendOperation colorOperation,
        BlendFactor srcAlphaFactor,
        BlendFactor dstAlphaFactor,
        BlendOperation alphaOperation)
    {
        var result = Sdl.ComposeCustomBlendMode(
            srcColorFactor,
            dstColorFactor,
            colorOperation,
            srcAlphaFactor,
            dstAlphaFactor,
            alphaOperation);
        return result == BlendMode.Invalid ? throw new SdlException(Sdl.GetError()) : result;
    }
}