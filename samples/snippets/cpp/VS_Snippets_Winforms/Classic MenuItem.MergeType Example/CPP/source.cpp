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

   // <Snippet1>
public:
   void InitMyFileMenu()
   {
      // Set the MergeType to Add so that the menu item is added to the merged menu.
      menuItem1->MergeType = MenuMerge::Add;
      // Set the MergeOrder to 1 so that this menu item is placed lower in the merged menu order.
      menuItem1->MergeOrder = 1;
   }
   // </Snippet1>
};
