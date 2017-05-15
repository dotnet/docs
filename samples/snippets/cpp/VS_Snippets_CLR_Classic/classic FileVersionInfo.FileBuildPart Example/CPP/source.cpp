#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

// <Snippet1>
private:
    void GetFileBuildPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo(Environment::SystemDirectory + "\\Notepad.exe");

        // Print the file build number.
        textBox1->Text = String::Format( "File build number: {0}", myFileVersionInfo->FileBuildPart );
    }
// </Snippet1>
};
