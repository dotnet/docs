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
   System::Windows::Forms::StatusBar^ statusBar1;
   System::Windows::Forms::StatusBarPanel^ statusBarPanel1;
   System::Windows::Forms::MainMenu^ mainMenu1;
   System::Windows::Forms::MenuItem^ menuItem1;
   System::Windows::Forms::MenuItem^ menuItem4;
   System::Windows::Forms::MenuItem^ menuOpen;
   System::Windows::Forms::MenuItem^ menuSave;
   System::Windows::Forms::MenuItem^ menuExit;

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
      this->statusBar1 = gcnew System::Windows::Forms::StatusBar;
      this->statusBarPanel1 = gcnew System::Windows::Forms::StatusBarPanel;
      this->mainMenu1 = gcnew System::Windows::Forms::MainMenu;
      this->menuItem1 = gcnew System::Windows::Forms::MenuItem;
      this->menuOpen = gcnew System::Windows::Forms::MenuItem;
      this->menuSave = gcnew System::Windows::Forms::MenuItem;
      this->menuItem4 = gcnew System::Windows::Forms::MenuItem;
      this->menuExit = gcnew System::Windows::Forms::MenuItem;
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->statusBarPanel1))->BeginInit();
      this->SuspendLayout();

      // 
      // statusBar1
      // 
      this->statusBar1->Location = System::Drawing::Point( 0, 496 );
      this->statusBar1->Name = "statusBar1";
      array<System::Windows::Forms::StatusBarPanel^>^temp0 = {this->statusBarPanel1};
      this->statusBar1->Panels->AddRange( temp0 );
      this->statusBar1->ShowPanels = true;
      this->statusBar1->Size = System::Drawing::Size( 536, 22 );
      this->statusBar1->TabIndex = 0;
      this->statusBar1->Text = "statusBar1";

      // 
      // statusBarPanel1
      // 
      this->statusBarPanel1->AutoSize = System::Windows::Forms::StatusBarPanelAutoSize::Spring;
      this->statusBarPanel1->Text = "statusBarPanel1";
      this->statusBarPanel1->Width = 520;

      // 
      // mainMenu1
      // 
      array<System::Windows::Forms::MenuItem^>^temp1 = {this->menuItem1};
      this->mainMenu1->MenuItems->AddRange( temp1 );

      // 
      // menuItem1
      // 
      this->menuItem1->Index = 0;
      array<System::Windows::Forms::MenuItem^>^temp2 = {this->menuOpen,this->menuSave,this->menuItem4,this->menuExit};
      this->menuItem1->MenuItems->AddRange( temp2 );
      this->menuItem1->Text = "&File";

      // 
      // menuOpen
      // 
      this->menuOpen->Index = 0;
      this->menuOpen->Text = "&Open";
      this->menuOpen->Select += gcnew System::EventHandler( this, &Form1::MenuSelected );

      // 
      // menuSave
      // 
      this->menuSave->Index = 1;
      this->menuSave->Text = "&Save";
      this->menuSave->Select += gcnew System::EventHandler( this, &Form1::MenuSelected );

      // 
      // menuItem4
      // 
      this->menuItem4->Index = 2;
      this->menuItem4->Text = "-";

      // 
      // menuExit
      // 
      this->menuExit->Index = 3;
      this->menuExit->Text = "E&xit";
      this->menuExit->Select += gcnew System::EventHandler( this, &Form1::MenuSelected );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 536, 518 );
      array<System::Windows::Forms::Control^>^temp3 = {this->statusBar1};
      this->Controls->AddRange( temp3 );
      this->Menu = this->mainMenu1;
      this->Name = "Form1";
      this->Text = "Form1";
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->statusBarPanel1))->EndInit();
      this->ResumeLayout( false );
   }

   //<Snippet1>
private:
   void MenuSelected( Object^ sender, System::EventArgs^ /*e*/ )
   {
      if ( sender == menuOpen )
            statusBar1->Panels[ 0 ]->Text = "Opens a file to edit";
      else
      if ( sender == menuSave )
            statusBar1->Panels[ 0 ]->Text = "Saves the current file";
      else
      if ( sender == menuExit )
            statusBar1->Panels[ 0 ]->Text = "Exits the application";
      else
            statusBar1->Panels[ 0 ]->Text = "Ready";
   }
   //</Snippet1>
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
