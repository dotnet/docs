// <Snippet1>
using System.Runtime.InteropServices;
using System;

// Declare a class member for each structure element.
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public class OpenFileName
{
    public int structSize = 0;
    public string filter = null;
    public string file = null;
    // ...
}

internal static class NativeMethods
{
    // Declare a managed prototype for the unmanaged function.
    [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode)]
    internal static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
}

public class MainMethod
{
    static void Main()
    { }
}
// </Snippet1>
