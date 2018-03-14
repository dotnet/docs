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
   MenuItem^ menuItem1;
   MenuItem^ menuItem2;

   // <Snippet1>
public:
   void SwitchMyMenuItems()
   {
      // Move menuItem1 down one position in the menu order.
      menuItem1->Index = menuItem1->Index + 1;
      // Move menuItem2 up one position in the menu order.
      menuItem2->Index = menuItem2->Index - 1;
   }
   // </Snippet1>
};
