using Microsoft.UI.Xaml;
using System;

namespace MastApp.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        try
        {
            this.InitializeComponent();
            this.UnhandledException += OnUnhandledException; // Attach exception handler
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"App Initialization Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles unhandled exceptions to prevent the app from crashing.
    /// </summary>
    private void OnUnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"Unhandled Exception: {e.Exception}");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {e.Exception.StackTrace}");
            e.Handled = true; // Prevent the app from crashing
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error while handling UnhandledException: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates the MAUI app instance.
    /// </summary>
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
