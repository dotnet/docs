//<snippet7>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

//<snippet8>
// Declare a class member for each structure element.
[StructLayout(LayoutKind::Sequential, CharSet=CharSet::Auto)]
public ref class OpenFileName
{
public:
    int       structSize;
    IntPtr    hwnd;
    IntPtr    hinst;
    String^   filter;
    String^   custFilter;
    int       custFilterMax;
    int       filterIndex;
    String^   file;
    int       maxFile;
    String^   fileTitle;
    int       maxFileTitle;
    String^   initialDir;
    String^   title;
    int       flags;
    short     fileOffset;
    short     fileExtMax;
    String^   defExt;
    int       custData;
    IntPtr    pHook;
    String^   tmplate;

    OpenFileName()
    {
        // Initialize the fields.
        for each (FieldInfo^ fi in this->GetType()->GetFields())
        {
            fi->SetValue(this, nullptr);
        }
    }
};

public ref class LibWrap
{
public:
    // Declare a managed prototype for the unmanaged function.
    [DllImport("Comdlg32.dll", CharSet=CharSet::Auto)]
    static bool GetOpenFileName([In, Out] OpenFileName^ ofn);
};
//</snippet8>

//<snippet9>
public ref class App
{
public:
    static void Main()
    {
        OpenFileName^ ofn = gcnew OpenFileName();

        ofn->structSize = Marshal::SizeOf(ofn);
        ofn->filter = "Log files\0*.log\0Batch files\0*.bat\0";
        ofn->file = gcnew String(gcnew array<Char>(256));
        ofn->maxFile = ofn->file->Length;
        ofn->fileTitle = gcnew String(gcnew array<Char>(64));
        ofn->maxFileTitle = ofn->fileTitle->Length;
        ofn->initialDir = "C:\\";
        ofn->title = "Open file called using platform invoke...";
        ofn->defExt = "txt";

        if (LibWrap::GetOpenFileName(ofn))
        {
            Console::WriteLine("Selected file with full path: {0}", ofn->file);
        }
    }
};
//</snippet9>
int main()
{
    App::Main();
}
//</snippet7>
