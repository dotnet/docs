

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
   MenuItem^ menuItem2;

public:

   // <Snippet1>
   void DisableMyChildMenus()
   {
      
      // Determine if menuItem2 is a parent menu.
      if ( menuItem2->IsParent == true )
      {
         
         // Loop through all the submenus.
         for ( int i = 0; i < menuItem2->MenuItems->Count; i++ )
         {
            
            // Disable all of the submenus of menuItem2.
            menuItem2->MenuItems[ i ]->Enabled = false;

         }
      }
   }

   // </Snippet1>
};