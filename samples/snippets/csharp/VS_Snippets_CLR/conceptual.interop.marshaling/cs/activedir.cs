//<snippet33>
using System;
using System.Runtime.InteropServices;

//<snippet34>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
public struct DsBrowseInfo
{
    public const int MAX_PATH = 256;

    public int       Size;
    public IntPtr    OwnerHandle;
    public string    Caption;
    public string    Title;
    public string    Root;
    public string    Path;
    public int       PathSize;
    public int       Flags;
    public IntPtr    Callback;
    public int       Param;
    public int       ReturnFormat;
    public string    UserName;
    public string    Password;
    public string    ObjectClass;
    public int       ObjectClassSize;
}

public class LibWrap
{
    // Declares a managed prototype for the unmanaged function.
    [DllImport("dsuiext.dll", CharSet=CharSet.Unicode)]
    public static extern int DsBrowseForContainerW(ref DsBrowseInfo info);

    public const int DSBI_ENTIREDIRECTORY = 0x00090000;
    public const int ADS_FORMAT_WINDOWS = 1;
    public enum BrowseStatus
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
        DsBrowseInfo dsbi = new DsBrowseInfo();

        dsbi.Size = Marshal.SizeOf(typeof(DsBrowseInfo));
        dsbi.PathSize = DsBrowseInfo.MAX_PATH;
        dsbi.Caption = "Container Selection Example";
        dsbi.Title = "Select a container from the list.";
        dsbi.ReturnFormat = LibWrap.ADS_FORMAT_WINDOWS;
        dsbi.Flags = LibWrap.DSBI_ENTIREDIRECTORY;
        dsbi.Root = "LDAP:";
        dsbi.Path = new string(new char[DsBrowseInfo.MAX_PATH]);
        // Initialize remaining members...

        int status = LibWrap.DsBrowseForContainerW(ref dsbi);
        if ((LibWrap.BrowseStatus)status == LibWrap.BrowseStatus.BrowseOk)
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
