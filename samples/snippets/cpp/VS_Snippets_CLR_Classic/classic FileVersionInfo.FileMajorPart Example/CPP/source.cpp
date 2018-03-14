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
   void GetFileMajorPart()
   {
      // Get the file version for the notepad.
      FileVersionInfo^ myFileVersionInfo = FileVersionInfo::GetVersionInfo( "%systemroot%\\Notepad.exe" );
      
      // Print the file major part number.
      textBox1->Text = String::Concat( "File major part number: ", myFileVersionInfo->FileMajorPart );
   }
   // </Snippet1>
};
