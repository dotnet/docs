// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;


public ref class Class1
{
    
public:
    static void Main()
    {
        // Get the file version for the notepad.
        // Use either of the two following methods.
        FileVersionInfo::GetVersionInfo(Path::Combine(Environment::SystemDirectory, "Notepad.exe"));
        FileVersionInfo^ myFileVersionInfo = FileVersionInfo::GetVersionInfo(Environment::SystemDirectory + "\\Notepad.exe");


        // Print the file name and version number.
        Console::WriteLine("File: " + myFileVersionInfo->FileDescription + "\n" +
           "Version number: " + myFileVersionInfo->FileVersion);
    }
};

int main()
{
    Class1::Main();
}
// </Snippet1>


