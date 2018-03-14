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
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;

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
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 184, 32 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // button2
      // 
      this->button2->Location = System::Drawing::Point( 200, 104 );
      this->button2->Name = "button2";
      this->button2->TabIndex = 1;
      this->button2->Text = "button2";
      this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button2,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      AddMyOwnedForm();
   }

   //<Snippet1>
private:
   void AddMyOwnedForm()
   {
      // Create form to be owned.
      Form^ ownedForm = gcnew Form;

      // Set the text of the owned form.
      ownedForm->Text = String::Format( "Owned Form {0}", this->OwnedForms->Length );

      // Add the form to the array of owned forms.
      this->AddOwnedForm( ownedForm );

      // Show the owned form.
      ownedForm->Show();
   }

   void ChangeOwnedFormText()
   {
      // Loop through all owned forms and change their text.
      for ( int x = 0; x < this->OwnedForms->Length; x++ )
      {
         this->OwnedForms[ x ]->Text = String::Format( "My Owned Form {0}", x );
      }
   }
   //</Snippet1>

   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ChangeOwnedFormText();
   }
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
