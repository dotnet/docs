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
   void SetupMyMenuItem()
   {
      // Set the caption for the menu item.
      menuItem1->Text = "&New";
      // Assign a shortcut key.
      menuItem1->Shortcut = Shortcut::CtrlN;
      // Make the menu item visible.
      menuItem1->Visible = true;
      // Display the shortcut key combination.
      menuItem1->ShowShortcut = true;
   }
   // </Snippet1>
};
