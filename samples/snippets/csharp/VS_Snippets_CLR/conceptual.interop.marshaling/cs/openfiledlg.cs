//<snippet7>
using System;
using System.Runtime.InteropServices;

//<snippet8>
// Declare a class member for each structure element.
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
public class OpenFileName
{
    public int       structSize = 0;
    public IntPtr    hwnd = IntPtr.Zero;
    public IntPtr    hinst = IntPtr.Zero;
    public string    filter = null;
    public string    custFilter = null;
    public int       custFilterMax = 0;
    public int       filterIndex = 0;
    public string    file = null;
    public int       maxFile = 0;
    public string    fileTitle = null;
    public int       maxFileTitle = 0;
    public string    initialDir = null;
    public string    title = null;
    public int       flags = 0;
    public short     fileOffset = 0;
    public short     fileExtMax = 0;
    public string    defExt = null;
    public int       custData = 0;
    public IntPtr    pHook = IntPtr.Zero;
    public string    template = null;
}

public class LibWrap
{
    // Declare a managed prototype for the unmanaged function.
    [DllImport("Comdlg32.dll", CharSet=CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
}
//</snippet8>

//<snippet9>
public class App
{
    public static void Main()
    {
        OpenFileName ofn = new OpenFileName();

        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.filter = "Log files\0*.log\0Batch files\0*.bat\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = "C:\\";
        ofn.title = "Open file called using platform invoke...";
        ofn.defExt = "txt";

        if (LibWrap.GetOpenFileName(ofn))
        {
            Console.WriteLine("Selected file with full path: {0}", ofn.file);
        }
    }
}
//</snippet9>
//</snippet7>
