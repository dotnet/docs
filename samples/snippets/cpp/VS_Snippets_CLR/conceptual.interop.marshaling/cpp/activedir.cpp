//<snippet33>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

//<snippet34>
[StructLayout(LayoutKind::Sequential, CharSet=CharSet::Unicode)]
public value struct DsBrowseInfo
{
public:
    static int MAX_PATH = 256;

    int        Size;
    IntPtr     OwnerHandle;
    String^    Caption;
    String^    Title;
    String^    Root;
    String^    Path;
    int        PathSize;
    int        Flags;
    IntPtr     Callback;
    int        Param;
    int        ReturnFormat;
    String^    UserName;
    String^    Password;
    String^    ObjectClass;
    int        ObjectClassSize;
};

public ref class LibWrap
{
public:
    // Declares a managed prototype for the unmanaged function.
    [DllImport("dsuiext.dll", CharSet=CharSet::Unicode)]
    static int DsBrowseForContainerW(DsBrowseInfo^ info);

    static int DSBI_ENTIREDIRECTORY = 0x00090000;
    static int ADS_FORMAT_WINDOWS = 1;
    enum class BrowseStatus
    {
        BrowseError = -1,
        BrowseOk = 1,
        BrowseCancel = 2
    };
};
//</snippet34>

//<snippet35>
public ref class App
{
public:
    // Must be marked as STA because the default is MTA.
    // DsBrowseForContainerW calls CoInitialize, which initializes the
    // COM library as STA.
    [STAThread]
    static void Main()
    {
        DsBrowseInfo dsbi;

        // Initialize the fields.
        dsbi.Size = Marshal::SizeOf(DsBrowseInfo::typeid);
        dsbi.PathSize = DsBrowseInfo::MAX_PATH;
        dsbi.Caption = "Container Selection Example";
        dsbi.Title = "Select a container from the list.";
        dsbi.ReturnFormat = LibWrap::ADS_FORMAT_WINDOWS;
        dsbi.Flags = LibWrap::DSBI_ENTIREDIRECTORY;
        dsbi.Root = "LDAP:";
        dsbi.Path = gcnew String(gcnew array<Char>(DsBrowseInfo::MAX_PATH));
        // Initialize remaining members...

        int status = LibWrap::DsBrowseForContainerW(dsbi);
        if ((LibWrap::BrowseStatus)status == LibWrap::BrowseStatus::BrowseOk)
        {
            Console::WriteLine(dsbi.Path);
        }
        else
        {
            Console::WriteLine("No path returned.");
        }
    }
};
//</snippet35>
int main()
{
    App::Main();
}
//</snippet33>
