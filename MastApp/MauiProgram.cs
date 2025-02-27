using System;
using System.Runtime.InteropServices;

namespace MastApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        LoadNativeLibrary();  // Ensure DLL is loaded

        return builder.Build();
    }

    private static void LoadNativeLibrary()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("#########################");
            Console.WriteLine("Inside the LoadNativeLibrary Method");
            Console.WriteLine("#########################");
            SetDllDirectory(@"C:\Users\INMOSAY1\Downloads\MastApp\MastApp\Libraries\");
        }
    }


    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool SetDllDirectory(string lpPathName);
}
