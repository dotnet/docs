#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

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
      InitializeMyMainMenu();

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
private:
   void InitializeMyMainMenu()
   {
      // Create the 2 menus and the menu items to add.
      MainMenu^ mainMenu1 = gcnew MainMenu;
      MainMenu^ mainMenu2 = gcnew MainMenu;
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;

      // Set the caption for the menu items.
      menuItem1->Text = "File";
      menuItem2->Text = "Edit";

      // Add a menu item to each menu for displaying.
      mainMenu1->MenuItems->Add( menuItem1 );
      mainMenu2->MenuItems->Add( menuItem2 );

      // Merge mainMenu2 with mainMenu1
      mainMenu1->MergeMenu( mainMenu2 );

      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;
   }
   // </snippet1>

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

// End Class CDesigner
// End nampspace CSMenuCommand
