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
   TextBox^ textBox1;

   // <Snippet1>
public:
   void CopyAllMyText()
   {
      // Determine if any text is selected in the TextBox control.
      if ( textBox1->SelectionLength == 0 )
      {
         // Select all text in the text box.
         textBox1->SelectAll();
      }

      // Copy the contents of the control to the Clipboard.
      textBox1->Copy();
   }
   // </Snippet1>
};
