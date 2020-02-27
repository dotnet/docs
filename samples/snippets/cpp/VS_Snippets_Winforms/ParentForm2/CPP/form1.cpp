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
   System::Windows::Forms::MdiClient^ mdiClient1;
   System::Windows::Forms::Button^ button1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;
      InitializeComponent();
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
      this->mdiClient1 = gcnew System::Windows::Forms::MdiClient;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      //
      // mdiClient1
      //
      this->mdiClient1->Dock = System::Windows::Forms::DockStyle::Fill;
      this->mdiClient1->Name = "mdiClient1";
      this->mdiClient1->TabIndex = 0;

      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 16, 16 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 80, 24 );
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 568, 368 );
      array<System::Windows::Forms::Control^>^formControls = {this->button1,this->mdiClient1};
      this->Controls->AddRange( formControls );
      this->IsMdiContainer = true;
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   // <snippet1>
   // The event handler on Form1.
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create an instance of Form2.
      Form1^ f2 = gcnew Form2;

      // Make this form the parent of f2.
      f2->MdiParent = this;

      // Display the form.
      f2->Show();
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
