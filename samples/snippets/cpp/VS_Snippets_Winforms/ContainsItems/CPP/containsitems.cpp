#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

ref class TestForm: public Form
{
public:
   TestForm()
   {
      InitializeMenu();
   }

   // <snippet1>
public:
   void InitializeMenu()
   {
      // Create the MainMenu object.
      MainMenu^ myMainMenu = gcnew MainMenu;
      
      // Create the MenuItem objects.
      MenuItem^ fileMenu = gcnew MenuItem( "&File" );
      MenuItem^ editMenu = gcnew MenuItem( "&Edit" );
      MenuItem^ newFile = gcnew MenuItem( "&New" );
      MenuItem^ openFile = gcnew MenuItem( "&Open" );
      MenuItem^ exitProgram = gcnew MenuItem( "E&xit" );
      
      // Add the MenuItem objects to myMainMenu.
      myMainMenu->MenuItems->Add( fileMenu );
      myMainMenu->MenuItems->Add( editMenu );
      
      // Add three submenus to the File menu.
      fileMenu->MenuItems->Add( newFile );
      fileMenu->MenuItems->Add( openFile );
      fileMenu->MenuItems->Add( exitProgram );
      
      // Assign myMainMenu to the form.
      Menu = myMainMenu;
      
      // Check that the File menu contains the Open menu item.
      if ( fileMenu->MenuItems->Contains( openFile ) )
      {
         MessageBox::Show( "The File menu contains 'Open' " + fileMenu->Text );
      }
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew TestForm );
}
