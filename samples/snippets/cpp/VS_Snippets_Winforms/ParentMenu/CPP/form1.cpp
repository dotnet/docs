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
      InitializeComponent();
      CreateMyMenuItems();
   }

protected:

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
   void CreateMyMenuItems()
   {
      // Craete a main menu object.
      MainMenu^ mainMenu1 = gcnew MainMenu;

      // Create three top-level menu items.
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&New" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Open" );

      // Add menuItem1 to the main menu.
      mainMenu1->MenuItems->Add( menuItem1 );

      // Add menuItem2 and menuItem3 to menuItem1.
      menuItem1->MenuItems->Add( menuItem2 );
      menuItem1->MenuItems->Add( menuItem3 );

      // Check to see if menuItem3 has a parent menu.
      if ( menuItem3->Parent != nullptr )
            MessageBox::Show( String::Concat( menuItem3->Parent, "." ), "Parent Menu Information of menuItem3" );
      else
            MessageBox::Show( "No parent menu." );

      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;
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
