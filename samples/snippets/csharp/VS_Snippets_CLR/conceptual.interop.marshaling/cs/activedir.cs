//<snippet33>
using System;
using System.Runtime.InteropServices;

//<snippet34>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DsBrowseInfo
{
    public const int MAX_PATH = 256;

    public int    Size;
    public IntPtr OwnerHandle;
    public string Caption;
    public string Title;
    public string Root;
    public string Path;
    public int    PathSize;
    public int    Flags;
    public IntPtr Callback;
    public int    Param;
    public int    ReturnFormat;
    public string UserName;
    public string Password;
    public string ObjectClass;
    public int    ObjectClassSize;
}

internal static class NativeMethods
{
    // Declares a managed prototype for the unmanaged function.
    [DllImport("dsuiext.dll", CharSet = CharSet.Unicode)]
    internal static extern int DsBrowseForContainerW(ref DsBrowseInfo info);

    internal const int DSBI_ENTIREDIRECTORY = 0x00090000;
    internal const int ADS_FORMAT_WINDOWS = 1;

    internal enum BrowseStatus
    {
        BrowseError = -1,
        BrowseOk = 1,
        BrowseCancel = 2
    }
}
//</snippet34>

//<snippet35>
class App
{
    // Must be marked as STA because the default is MTA.
    // DsBrowseForContainerW calls CoInitialize, which initializes the
    // COM library as STA.
    [STAThread]
    public static void Main()
    {
        DsBrowseInfo dsbi = new DsBrowseInfo
        {
            Size = Marshal.SizeOf(typeof(DsBrowseInfo)),
            PathSize = DsBrowseInfo.MAX_PATH,
            Caption = "Container Selection Example",
            Title = "Select a container from the list.",
            ReturnFormat = NativeMethods.ADS_FORMAT_WINDOWS,
            Flags = NativeMethods.DSBI_ENTIREDIRECTORY,
            Root = "LDAP:",
            Path = new string(new char[DsBrowseInfo.MAX_PATH])
        };

        // Initialize remaining members...
        int status = NativeMethods.DsBrowseForContainerW(ref dsbi);
        if ((NativeMethods.BrowseStatus)status == NativeMethods.BrowseStatus.BrowseOk)
        {
            Console.WriteLine(dsbi.Path);
        }
        else
        {
            Console.WriteLine("No path returned.");
        }
    }
}
//</snippet35>
//</snippet33>
