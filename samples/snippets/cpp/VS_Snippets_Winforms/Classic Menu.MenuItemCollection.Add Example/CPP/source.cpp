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
private:
   void InitializeMyMainMenu()
   {
      // Create the MainMenu.
      MainMenu^ mainMenu1 = gcnew MainMenu;
      
      /* Use the MenuItems property to call the Add method
         to add two new MenuItem objects to the MainMenu. */
      mainMenu1->MenuItems->Add( "&File" );
      mainMenu1->MenuItems->Add( "&Edit" );
      
      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;
   }
   // </Snippet1>
};
