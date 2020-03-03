#using <system.dll>
#using <system.data.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>
#using <system.xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
public:
   void CreateMyPanel()
   {
      Panel^ panel1 = gcnew Panel;
      TextBox^ textBox1 = gcnew TextBox;
      Label^ label1 = gcnew Label;
      
      // Initialize the Panel control.
      panel1->Location = System::Drawing::Point( 56, 72 );
      panel1->Size = System::Drawing::Size( 264, 152 );
      // Set the Borderstyle for the Panel to three-dimensional.
      panel1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      
      // Initialize the Label and TextBox controls.
      label1->Location = System::Drawing::Point( 16, 16 );
      label1->Text = "label1";
      label1->Size = System::Drawing::Size( 104, 16 );
      textBox1->Location = System::Drawing::Point( 16, 32 );
      textBox1->Text = "";
      textBox1->Size = System::Drawing::Size( 152, 20 );
      
      // Add the Panel control to the form.
      this->Controls->Add( panel1 );
      // Add the Label and TextBox controls to the Panel.
      panel1->Controls->Add( label1 );
      panel1->Controls->Add( textBox1 );
   }
   // </Snippet1>
};
