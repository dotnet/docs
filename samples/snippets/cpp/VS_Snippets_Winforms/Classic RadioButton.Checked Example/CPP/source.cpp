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
private:
   ListBox^ listBox1;
   RadioButton^ radioButton1;
   RadioButton^ radioButton2;

   // <Snippet1>
private:
   void ClickMyRadioButton()
   {
      // If Item1 is selected and radioButton2 
      // is checked, click radioButton1.
      if ( listBox1->Text == "Item1" && radioButton2->Checked )
      {
         radioButton1->PerformClick();
      }
   }
   // </Snippet1>
};
