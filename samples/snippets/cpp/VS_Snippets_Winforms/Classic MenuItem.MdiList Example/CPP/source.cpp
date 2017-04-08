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
   TextBox^ textBox1;

   // <Snippet1>
public:
   void SetMDIList()
   {
      // Create the MenuItem to be used to display an MDI list.
      MenuItem^ menuItem1 = gcnew MenuItem;
      // Set this menu item to be used as an MDI list.
      menuItem1->MdiList = true;
   }
   // </Snippet1>
};
