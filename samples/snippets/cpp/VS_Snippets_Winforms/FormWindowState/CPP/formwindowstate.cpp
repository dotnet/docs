#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

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
      label1->Location = System::Drawing::Point( 54, 128 );
      label1->Name = "label1";
      label1->Size = System::Drawing::Size( 220, 80 );
      label1->Text = "Start position information";
      this->Controls->Add( label1 );
      
      // Changes the window state to Maximized.
      WindowState = FormWindowState::Maximized;
      
      // Displays the state information.
      label1->Text = String::Format( "The form window is {0}", WindowState );
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew TestForm );
}
