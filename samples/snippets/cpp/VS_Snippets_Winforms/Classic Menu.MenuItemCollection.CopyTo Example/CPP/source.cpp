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
   void CopyMyMenus()
   {
      // Create empty array to store MenuItem objects.
      array<MenuItem^>^ myItems = gcnew array<MenuItem^>(
         menuItem1->MenuItems->Count + menuItem2->MenuItems->Count );
      
      // Copy elements of the first MenuItem collection to array.
      menuItem1->MenuItems->CopyTo( myItems, 0 );
      // Copy elements of the second MenuItem collection, after the first set.
      menuItem2->MenuItems->CopyTo( myItems, myItems->Length );
      
      // Add the array to the menu item collection of the ContextMenu.
      contextMenu1->MenuItems->AddRange( myItems );
   }
   // </Snippet1>
};
