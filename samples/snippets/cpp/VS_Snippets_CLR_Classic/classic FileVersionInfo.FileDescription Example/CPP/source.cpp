#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Diagnostics;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

// <Snippet1>
private:
    void GetFileDescription()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
        FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the file description.
        textBox1->Text = String::Concat( "File description: ", myFileVersionInfo->FileDescription );
    }
// </Snippet1>
};
