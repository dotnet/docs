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
   void CreateMyMenu()
   {
      // Create an empty menu item object.
      MenuItem^ menuItem1 = gcnew MenuItem;
      // Intialize the menu item using the parameterless version of the constructor.
      // Set the caption of the menu item.
      menuItem1->Text = "&File";
   }
   // </Snippet1>
};
