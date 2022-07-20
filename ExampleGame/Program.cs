using System.Diagnostics;

using Vitimiti.Sdl2;
using Vitimiti.Sdl2.Utils;

namespace ExampleGame;

internal static class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine($"Using SDL v{SdlApplication.SdlVersion} [{SdlApplication.Revision}] on {Platform.Name}.");
            using (var app = new SdlApplication(Subsystems.Everything))
            {
                Debug.WriteLine($"Initialized SDL with flags [{SdlApplication.InitializedSubsystems}]");

                app.StopSubsystems(Subsystems.Video);
                Debug.WriteLine($"Initialized SDL with flags [{SdlApplication.InitializedSubsystems}]");

                app.AddSubsystems(Subsystems.Video);
                Debug.WriteLine($"Initialized SDL with flags [{SdlApplication.InitializedSubsystems}]");
            }

            Debug.WriteLine($"Terminated SDL, running flags [{SdlApplication.InitializedSubsystems}]");
        }
        catch (SdlException exception)
        {
            Console.Error.WriteLine($"{exception}");
            throw;
        }
    }
}