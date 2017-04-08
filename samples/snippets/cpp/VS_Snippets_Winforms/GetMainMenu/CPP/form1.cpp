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
   System::Windows::Forms::Label ^ label1;

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
      this->label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();

      //
      // label1
      //
      this->label1->Location = System::Drawing::Point( 24, 128 );
      this->label1->Name = "label1";
      this->label1->Size = System::Drawing::Size( 240, 88 );
      this->label1->TabIndex = 0;
      this->label1->Text = "label1";

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 276 );
      array<System::Windows::Forms::Control^>^formControls = {this->label1};
      this->Controls->AddRange( formControls );
      this->Name = "Form1";
      this->Text = "My Form";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   // <snippet1>
private:
   void InitializeMyMainMenu()
   {
      // Create the MainMenu and the menu items to add.
      MainMenu^ mainMenu1 = gcnew MainMenu;
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;
      MenuItem^ menuItem3 = gcnew MenuItem;
      MenuItem^ menuItem4 = gcnew MenuItem;

      // Set the caption for the menu items.
      menuItem1->Text = "File";
      menuItem2->Text = "Edit";
      menuItem3->Text = "View";

      // Add 3 menu items to the MainMenu for displaying.
      mainMenu1->MenuItems->Add( menuItem1 );
      mainMenu1->MenuItems->Add( menuItem2 );
      mainMenu1->MenuItems->Add( menuItem3 );

      // Assign mainMenu1 to the form.
      Menu = mainMenu1;

      // Determine whether menuItem3 is currently being used.
      if ( menuItem3->GetMainMenu() != nullptr )

      // Display the name of the form in which it is located.
      label1->Text = menuItem3->GetMainMenu()->GetForm()->ToString();
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
