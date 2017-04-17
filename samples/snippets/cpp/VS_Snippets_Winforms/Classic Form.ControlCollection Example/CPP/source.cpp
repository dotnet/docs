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
   // <Snippet1>
public:
   void AddMyControls()
   {
      TextBox^ textBox1 = gcnew TextBox;
      Label^ label1 = gcnew Label;
      
      // Initialize the controls and their bounds.
      label1->Text = "First Name";
      label1->Location = Point( 48, 48 );
      label1->Size = System::Drawing::Size( 104, 16 );
      textBox1->Text = "";
      textBox1->Location = Point(48,64);
      textBox1->Size = System::Drawing::Size( 104, 16 );
      
      // Add the TextBox control to the form's control collection.
      Controls->Add( textBox1 );
      // Add the Label control to the form's control collection.
      Controls->Add( label1 );
   }
   // </Snippet1>
};
