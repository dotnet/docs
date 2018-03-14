#using <system.dll>
#using <System.Drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
private:
   void InitializeMyButton()
   {
      // Create and initialize a Button.
      Button^ button1 = gcnew Button;
      
      // Set the button to return a value of OK when clicked.
      button1->DialogResult = ::DialogResult::OK;
      
      // Add the button to the form.
      Controls->Add( button1 );
   }
   // </Snippet1>
};
