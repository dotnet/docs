#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

public ref class Form1 : public Form
{
protected:
    TextBox^ textBox1;

// <Snippet1>
private:
    void GetIsPrivateBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print whether the version is a private build.
        textBox1->Text = String::Concat( "Version is a private build: ", myFileVersionInfo->IsPrivateBuild );
    }
// </Snippet1>
};
