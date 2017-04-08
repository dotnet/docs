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
   // <Snippet1>
public:
   void CreateMyMenus()
   {
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&New" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Open" );
      // Make menuItem2 the default menu item.
      menuItem2->DefaultItem = true;
   }
   // </Snippet1>
};
