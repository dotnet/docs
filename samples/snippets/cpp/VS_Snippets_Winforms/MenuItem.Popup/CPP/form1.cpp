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
   System::Windows::Forms::MainMenu^ mainMenu1;
   System::Windows::Forms::MenuItem^ menuEdit;
   System::Windows::Forms::MenuItem^ menuCut;
   System::Windows::Forms::MenuItem^ menuCopy;
   System::Windows::Forms::MenuItem^ menuPaste;
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::MenuItem^ menuDelete;

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
      this->mainMenu1 = gcnew System::Windows::Forms::MainMenu;
      this->menuEdit = gcnew System::Windows::Forms::MenuItem;
      this->menuCut = gcnew System::Windows::Forms::MenuItem;
      this->menuCopy = gcnew System::Windows::Forms::MenuItem;
      this->menuPaste = gcnew System::Windows::Forms::MenuItem;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->menuDelete = gcnew System::Windows::Forms::MenuItem;
      this->SuspendLayout();

      // 
      // mainMenu1
      // 
      array<System::Windows::Forms::MenuItem^>^temp0 = {this->menuEdit};
      this->mainMenu1->MenuItems->AddRange( temp0 );

      // 
      // menuEdit
      // 
      this->menuEdit->Index = 0;
      array<System::Windows::Forms::MenuItem^>^temp1 = {this->menuCut,this->menuCopy,this->menuPaste,this->menuDelete};
      this->menuEdit->MenuItems->AddRange( temp1 );
      this->menuEdit->Text = "&Edit";
      this->menuEdit->Popup += gcnew System::EventHandler( this, &Form1::PopupMyMenu );

      // 
      // menuCut
      // 
      this->menuCut->Index = 0;
      this->menuCut->Text = "Cu&t";

      // 
      // menuCopy
      // 
      this->menuCopy->Index = 1;
      this->menuCopy->Text = "&Copy";

      // 
      // menuPaste
      // 
      this->menuPaste->Index = 2;
      this->menuPaste->Text = "&Paste";

      // 
      // textBox1
      // 
      this->textBox1->Location = System::Drawing::Point( 120, 153 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 168, 20 );
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "textBox1";

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 304, 152 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";

      // 
      // menuDelete
      // 
      this->menuDelete->Index = 3;
      this->menuDelete->Text = "&Delete";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 408, 326 );
      array<System::Windows::Forms::Control^>^temp2 = {this->button1,this->textBox1};
      this->Controls->AddRange( temp2 );
      this->Menu = this->mainMenu1;
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<Snippet1>
private:
   void PopupMyMenu( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( textBox1->Enabled == false || textBox1->Focused == false || textBox1->SelectedText->Length == 0 )
      {
         menuCut->Enabled = false;
         menuCopy->Enabled = false;
         menuDelete->Enabled = false;
      }
      else
      {
         menuCut->Enabled = true;
         menuCopy->Enabled = true;
         menuDelete->Enabled = true;
      }
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
