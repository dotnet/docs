#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
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
      
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      CloneMyMainMenu();
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

   /// <summary>
   /// The main entry point for the application.
   /// </summary>

   [STAThread]
   // <snippet1>
   void CloneMyMainMenu()
   {
      // Create the main menu.
      MainMenu^ mainMenu1 = gcnew MainMenu;

      // Create the menu items to add.
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;
      MenuItem^ menuItem3 = gcnew MenuItem;

      // Set the caption for the menu items.
      menuItem1->Text = "File";
      menuItem2->Text = "Edit";
      menuItem3->Text = "View";

      // Add the menu item to mainMenu1.
      mainMenu1->MenuItems->Add( menuItem1 );
      mainMenu1->MenuItems->Add( menuItem2 );
      mainMenu1->MenuItems->Add( menuItem3 );

      // Clone the mainMenu1 and name it mainMenu2.
      MainMenu^ mainMenu2 = mainMenu1->CloneMenu();

      // Assign mainMenu2 to the form.
      Menu = mainMenu2;
   }
   // </snippet1>

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
};

int main()
{
   Application::Run( gcnew Form1 );
}
