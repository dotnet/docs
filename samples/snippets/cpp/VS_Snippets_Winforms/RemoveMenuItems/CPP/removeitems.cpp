#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      InitializeMyMenu();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }


public:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 276 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
   }

   // <snippet1>
public:
   void InitializeMyMenu()
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

      // Remove the item S"Open" from the File menu.
      fileMenu->MenuItems->Remove( openFile );
   }
   // </snippet1>

private:
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
