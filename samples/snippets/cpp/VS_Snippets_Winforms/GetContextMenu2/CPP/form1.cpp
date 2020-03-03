#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
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
      AddContextmenu();

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

   /// <summary>
   /// The main entry point for the application.
   /// </summary>

   // <snippet1>
public:
   [STAThread]
   void AddContextmenu()
   {
      // Create a shortcut menu.
      System::Windows::Forms::ContextMenu^ m = gcnew System::Windows::Forms::ContextMenu;
      this->ContextMenu = m;

      // Create MenuItem objects.
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;

      // Set the Text property.
      menuItem1->Text = "New";
      menuItem2->Text = "Open";

      // Add menu items to the MenuItems collection.
      m->MenuItems->Add( menuItem1 );
      m->MenuItems->Add( menuItem2 );

      // Display the starting message.
      MessageBox::Show( "Right-click the form to display the shortcut menu items" );

      // Add functionality to the menu items. 
      menuItem1->Click += gcnew System::EventHandler( this, &Form1::menuItem1_Click );
      menuItem2->Click += gcnew System::EventHandler( this, &Form1::menuItem2_Click );
   }

private:
   void menuItem1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      String^ textReport = "You clicked the New menu item. \n"
      "It is contained in the following shortcut menu: \n\n";

      // Get information on the shortcut menu in which menuitem1 is contained.
      textReport = String::Concat( textReport, this->ContextMenu->GetContextMenu()->ToString() );

      // Display the shortcut menu information in a message box.
      MessageBox::Show( textReport, "The ContextMenu Information" );
   }

   void menuItem2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      String^ textReport = "You clicked the Open menu item. \n"
      "It is contained in the following shortcut menu: \n\n";

      // Get information on the shortcut menu in which menuitem1 is contained.
      textReport = String::Concat( textReport, this->ContextMenu->GetContextMenu()->ToString() );

      // Display the shortcut menu information in a message box.
      MessageBox::Show( textReport, "The ContextMenu Information" );
   }
   // </snippet1>

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
};

int main()
{
   Application::Run( gcnew Form1 );
}
