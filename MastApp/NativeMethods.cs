//using System;
//using System.Runtime.InteropServices;

//public static partial class NativeMethods
//{
//    // Specify the folder where the DLL is located
//    private const string DllPath = @"C:\Users\INMOSAY1\Downloads\MastApp\MastApp\Platforms\Windows\";
//    private const string DllName = "calculator.dll";

//    // Ensure the correct DLL path is set
//    static NativeMethods()
//    {
//        if (!SetDllDirectory(DllPath))
//        {
//            throw new Exception("Failed to set DLL directory: " + DllPath);
//        }
//    }

//    [DllImport("kernel32.dll", SetLastError = true)]
//    private static extern bool SetDllDirectory(string lpPathName);

//    // Function imports from calculator.dll
//    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Add")]
//    public static extern double Add(double a, double b);

//    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Subtract")]
//    public static extern double Subtract(double a, double b);

//    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Multiply")]
//    public static extern double Multiply(double a, double b);

//    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Divide")]
//    public static extern double Divide(double a, double b);
//}

using System.Runtime.InteropServices;

namespace MastApp;

internal static partial class NativeMethods
{
    private const string DllName = "calculator.dll";

    [LibraryImport(DllName, EntryPoint = "Add")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial int Add(double a, double b);

    [LibraryImport(DllName, EntryPoint = "Subtract")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial int Subtract(double a, double b);

    [LibraryImport(DllName, EntryPoint = "Multiply")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial int Multiply(double a, double b);

    [LibraryImport(DllName, EntryPoint = "Divide")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial int Divide(double a, double b);
}
