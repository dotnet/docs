#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

ref class TestForm: public Form
{
public:
   TestForm()
   {
      InitMyForm();
   }

   // <snippet1>
public:
   void InitMyForm()
   {
      // Adds a label to the form.
      Label^ label1 = gcnew Label;
      label1->Location = System::Drawing::Point( 80, 80 );
      label1->Name = "label1";
      label1->Size = System::Drawing::Size( 132, 80 );
      label1->Text = "Start Position Information";
      this->Controls->Add( label1 );
      
      // Changes the border to Fixed3D.
      FormBorderStyle = ::FormBorderStyle::Fixed3D;
      
      // Displays the border information.
      label1->Text = String::Format( "The border is {0}", FormBorderStyle );
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew TestForm );
}
