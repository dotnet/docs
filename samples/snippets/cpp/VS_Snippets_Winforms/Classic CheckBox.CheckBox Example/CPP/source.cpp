#using <system.dll>
#using <System.Drawing.dll>
#using <system.data.dll>
#using <system.windows.forms.dll>

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
   void InstantiateMyCheckBox()
   {
      // Create and initialize a CheckBox.   
      CheckBox^ checkBox1 = gcnew CheckBox;
      
      // Make the check box control appear as a toggle button.
      checkBox1->Appearance = Appearance::Button;
      
      // Turn off the update of the display on the click of the control.
      checkBox1->AutoCheck = false;
      
      // Add the check box control to the form.
      this->Controls->Add( checkBox1 );
   }
   // </Snippet1>
};
