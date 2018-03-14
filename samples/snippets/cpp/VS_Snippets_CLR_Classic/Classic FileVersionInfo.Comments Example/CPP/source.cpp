#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

public ref class Form1: Form
{
protected:
    TextBox^ textBox1;
    // <Snippet1>
    void GetComments()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo(Environment::SystemDirectory + "\\Notepad.exe");
        // Print the comments in a text box.
        textBox1->Text = "Comments: " + myFileVersionInfo->Comments;
    }
// </Snippet1>
};
