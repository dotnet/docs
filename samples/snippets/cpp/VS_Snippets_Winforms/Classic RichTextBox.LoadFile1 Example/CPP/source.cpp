#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   RichTextBox^ richTextBox1;

   // <Snippet1>
public:
   void LoadMyFile()
   {
      // Create an OpenFileDialog to request a file to open.
      OpenFileDialog^ openFile1 = gcnew OpenFileDialog;
      
      // Initialize the OpenFileDialog to look for RTF files.
      openFile1->DefaultExt = "*.rtf";
      openFile1->Filter = "RTF Files|*.rtf";
      
      // Determine whether the user selected a file from the OpenFileDialog.
      if ( openFile1->ShowDialog() == System::Windows::Forms::DialogResult::OK &&
         openFile1->FileName->Length > 0 )
      {
         // Load the contents of the file into the RichTextBox.
         richTextBox1->LoadFile( openFile1->FileName, RichTextBoxStreamType::PlainText );
      }
   }
   // </Snippet1>
};
