

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

public:

   // <Snippet1>
   void CreateMyMainMenu()
   {
      // Create an empty MainMenu.
      MainMenu^ mainMenu1 = gcnew MainMenu;
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;
      menuItem1->Text = "File";
      menuItem2->Text = "Edit";

      // Add two MenuItem objects to the MainMenu.
      mainMenu1->MenuItems->Add( menuItem1 );
      mainMenu1->MenuItems->Add( menuItem2 );

      // Bind the MainMenu to Form1.
      Menu = mainMenu1;
   }
   // </Snippet1>
};
