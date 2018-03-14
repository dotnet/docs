#using <system.dll>
#using <system.data.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Sample
{
private:
   RadioButton^ radioButton1;

   // <Snippet1>
private:
   Void radioButton1_CheckedChanged( System::Object^ sender,
      System::EventArgs^ e )
   {
      // Change the check box position to be opposite its current position.
      if ( radioButton1->CheckAlign == ContentAlignment::MiddleLeft )
      {
         radioButton1->CheckAlign = ContentAlignment::MiddleRight;
      }
      else
      {
         radioButton1->CheckAlign = ContentAlignment::MiddleLeft;
      }
   }
   // </Snippet1>
};
