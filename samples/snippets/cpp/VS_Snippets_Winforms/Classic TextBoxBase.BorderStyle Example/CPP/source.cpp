#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
public:
   void CreateTextBox()
   {
      // Create an instance of the TextBox control.
      TextBox^ textBox1 = gcnew TextBox;
      
      // Set the TextBox Font property to Arial 20.
      textBox1->Font = gcnew System::Drawing::Font( "Arial", 20 );
      // Set the BorderStyle property to FixedSingle.
      textBox1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      // Make the height of the control equal to the preferred height.
      textBox1->Height = textBox1->PreferredHeight;
   }
   // </Snippet1>
};
