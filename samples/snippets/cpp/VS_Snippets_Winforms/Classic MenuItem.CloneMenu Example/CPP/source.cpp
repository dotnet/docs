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
   System::Windows::Forms::ContextMenu^ contextMenu1;

   // <Snippet1>
public:
   void CloneMyMenu()
   {
      // Clone the menu item and add it to the collection for the shortcut menu.
      contextMenu1->MenuItems->Add( menuItem1->CloneMenu() );
   }
   // </Snippet1>
};
