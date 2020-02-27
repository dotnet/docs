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
   void SaveMyFile()
   {
      // Create a SaveFileDialog to request a path and file name to save to.
      SaveFileDialog^ saveFile1 = gcnew SaveFileDialog;
      
      // Initialize the SaveFileDialog to specify the RTF extention for the file.
      saveFile1->DefaultExt = "*.rtf";
      saveFile1->Filter = "RTF Files|*.rtf";
      
      // Determine whether the user selected a file name from the saveFileDialog.
      if ( saveFile1->ShowDialog() == System::Windows::Forms::DialogResult::OK &&
         saveFile1->FileName->Length > 0 )
      {
         // Save the contents of the RichTextBox into the file.
         richTextBox1->SaveFile( saveFile1->FileName );
      }
   }
   // </Snippet1>
};
