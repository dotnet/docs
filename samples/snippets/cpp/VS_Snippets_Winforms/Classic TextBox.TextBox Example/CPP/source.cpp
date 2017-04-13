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
   void CreateMyTextBoxControl()
   {
      // Create a new TextBox control using this constructor.
      TextBox^ textBox1 = gcnew TextBox;
      // Assign a string of text to the new TextBox control.
      textBox1->Text = "Hello World!";
      // Code goes here to add the control to the form's control collection.
   }
   // </Snippet1>
};
