#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
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
   void ChangeMySelectionColor()
   {
      ColorDialog^ colorDialog1 = gcnew ColorDialog;
      
      // Set the initial color of the dialog to the current text color.
      colorDialog1->Color = richTextBox1->SelectionColor;
      
      // Determine if the user clicked OK in the dialog and that the color has changed.
      if ( colorDialog1->ShowDialog() == System::Windows::Forms::DialogResult::OK &&
         colorDialog1->Color != richTextBox1->SelectionColor )
      {
         // Change the selection color to the user specified color.
         richTextBox1->SelectionColor = colorDialog1->Color;
      }
   }
   // </Snippet1>
};
