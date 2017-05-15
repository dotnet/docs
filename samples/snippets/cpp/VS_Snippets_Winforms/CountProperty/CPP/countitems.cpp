#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

ref class TestForm: public Form
{
   // <snippet1>
public:
   void InitializeMyMenu()
   {
      // Create the MainMenu Object*.
      MainMenu^ myMainMenu = gcnew MainMenu;
      
      // Create the MenuItem objects.
      MenuItem^ fileMenu = gcnew MenuItem( "&File" );
      MenuItem^ newFile = gcnew MenuItem( "&New" );
      MenuItem^ openFile = gcnew MenuItem( "&Open" );
      MenuItem^ exitProgram = gcnew MenuItem( "E&xit" );
      
      // Add the File menu item to myMainMenu.
      myMainMenu->MenuItems->Add( fileMenu );
      
      // Add three submenus to the File menu.
      fileMenu->MenuItems->Add( newFile );
      fileMenu->MenuItems->Add( openFile );
      fileMenu->MenuItems->Add( exitProgram );
      
      // Assign myMainMenu to the form.
      this->Menu = myMainMenu;
      
      // Count the number of objects in the File menu and display the result.
      String^ objectNumber = fileMenu->MenuItems->Count.ToString();
      MessageBox::Show( "Number of objects in the File menu = " + objectNumber );
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew TestForm );
}
