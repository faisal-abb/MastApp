using System.Runtime.InteropServices;
using System.Text;

namespace MastApp;

internal static partial class NativeMethods
{
    private const string DllName = "calculatorWrapper.dll";

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern uint GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, uint nSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    public static string GetLoadedDllPath()
    {
        IntPtr hModule = GetModuleHandle(DllName);
        if (hModule == IntPtr.Zero)
        {
            return "DLL not loaded";
        }

        var path = new StringBuilder(260);
        GetModuleFileName(hModule, path, (uint)path.Capacity);
        return path.ToString();
    }

    [LibraryImport(DllName, EntryPoint = "AddWrapper")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double AddWrapper(double a, double b); // FIX: Return type should be `double`

    [LibraryImport(DllName, EntryPoint = "SubtractWrapper")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double SubtractWrapper(double a, double b); // FIX

    [LibraryImport(DllName, EntryPoint = "MultiplyWrapper")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double MultiplyWrapper(double a, double b); // FIX

    [LibraryImport(DllName, EntryPoint = "DivideWrapper")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial double DivideWrapper(double a, double b); // FIX

    //[LibraryImport(DllName, EntryPoint = "printHello")]
    //[UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    //[return: MarshalAs(UnmanagedType.LPStr)] // FIX: Marshal return type correctly
    //public static partial string printHello();
}