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
   void CreateMyMenuItem()
   {
      // Submenu item array.
      array<MenuItem^>^ subMenus = gcnew array<MenuItem^>(3);
      // Create three menu items to add to the submenu item array.
      MenuItem^ subMenuItem1 = gcnew MenuItem( "Red" );
      MenuItem^ subMenuItem2 = gcnew MenuItem( "Blue" );
      MenuItem^ subMenuItem3 = gcnew MenuItem( "Green" );
      
      // Add the submenu items to the array.
      subMenus[ 0 ] = subMenuItem1;
      subMenus[ 1 ] = subMenuItem2;
      subMenus[ 2 ] = subMenuItem3;
      /* Create a MenuItem with caption, shortcut key, 
         a Click, Popup, and Select event handler, merge type and order, and an 
         array of submenu items specified.
      */
      MenuItem^ menuItem1 = gcnew MenuItem( MenuMerge::Add, 0,
         Shortcut::CtrlShiftC, "&Colors",
         gcnew EventHandler( this, &Form1::MenuItem1_Click ),
         gcnew EventHandler( this, &Form1::MenuItem1_Popup ),
         gcnew EventHandler( this, &Form1::MenuItem1_Select ), subMenus );
   }

private:
   // The following method is an event handler for menuItem1 to use when connecting the Click event.
   void MenuItem1_Click( Object^ sender, EventArgs^ e )
   {
      // Code goes here that handles the Click event.
   }

   // The following method is an event handler for menuItem1 to use  when connecting the Popup event.
   void MenuItem1_Popup( Object^ sender, EventArgs^ e )
   {
      // Code goes here that handles the Click event.
   }

   // The following method is an event handler for menuItem1 to use  when connecting the Select event
   void MenuItem1_Select( Object^ sender, EventArgs^ e )
   {
      // Code goes here that handles the Click event.
   }
   // </Snippet1>
};
