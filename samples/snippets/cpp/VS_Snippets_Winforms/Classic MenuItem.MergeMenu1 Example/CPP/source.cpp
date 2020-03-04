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
   System::Windows::Forms::ContextMenu^ contextMenu1;

   // <Snippet1>
private:
   void MergeMyMenus()
   {
      // Set the merge type to merge the items from both top menu items.
      menuItem1->MergeType = MenuMerge::MergeItems;
      menuItem2->MergeType = MenuMerge::MergeItems;
      // Create a copy of my menu item.
      MenuItem^ tempMenuItem = gcnew MenuItem;
      // Create a copy of menuItem1 before doing the merge.
      tempMenuItem = menuItem1->CloneMenu();
      // Merge menuItem1's copy with a clone of menuItem2
      tempMenuItem->MergeMenu( menuItem2->CloneMenu() );
      
      // Add the merged menu to the ContextMenu control.
      contextMenu1->MenuItems->Add( tempMenuItem );
   }
   // </Snippet1>
};
