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
   void CreateMyMultilineTextBox()
   {
      // Create an instance of a TextBox control.
      TextBox^ textBox1 = gcnew TextBox;
      
      // Set the Multiline property to true.
      textBox1->Multiline = true;
      // Add vertical scroll bars to the TextBox control.
      textBox1->ScrollBars = ScrollBars::Vertical;
      // Allow the TAB key to be entered in the TextBox control.
      textBox1->AcceptsReturn = true;
      // Allow the TAB key to be entered in the TextBox control.
      textBox1->AcceptsTab = true;
      // Set WordWrap to true to allow text to wrap to the next line.
      textBox1->WordWrap = true;
      // Set the default text of the control.
      textBox1->Text = "Welcome!";
   }
   // </Snippet1>
};
