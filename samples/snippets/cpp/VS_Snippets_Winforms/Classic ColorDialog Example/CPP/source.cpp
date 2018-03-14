#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ColorDialog^ MyDialog = gcnew ColorDialog;
      // Keeps the user from selecting a custom color.
      MyDialog->AllowFullOpen = false;
      // Allows the user to get help. (The default is false.)
      MyDialog->ShowHelp = true;
      // Sets the initial color select to the current text color.
      MyDialog->Color = textBox1->ForeColor;
      
      // Update the text box color if the user clicks OK 
      if ( MyDialog->ShowDialog() == ::System::Windows::Forms::DialogResult::OK )
      {
         textBox1->ForeColor = MyDialog->Color;
      }
   }
   // </Snippet1>
};
