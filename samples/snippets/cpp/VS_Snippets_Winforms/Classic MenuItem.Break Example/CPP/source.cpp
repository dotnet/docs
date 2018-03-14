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
   void CreateMyMenus()
   {
      // Create three top-level menu items.
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&Options" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Edit" );
      // Place the "Edit" menu on a new line in the menu bar.
      menuItem3->Break = true;
   }
   // </Snippet1>
};
