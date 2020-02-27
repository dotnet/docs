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
   static String^ strMyOriginalText = "";
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::TextBox^ textBox1;

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
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 200, 64 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";

      // 
      // textBox1
      // 
      this->textBox1->Location = System::Drawing::Point( 48, 64 );
      this->textBox1->Name = "textBox1";
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "textBox1";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->textBox1,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Closing += gcnew System::ComponentModel::CancelEventHandler( this, &Form1::Form1_Closing );
      this->ResumeLayout( false );
   }

   //<Snippet1>
private:
   void Form1_Closing( Object^ /*sender*/, System::ComponentModel::CancelEventArgs^ e )
   {
      // Determine if text has changed in the textbox by comparing to original text.
      if ( textBox1->Text != strMyOriginalText )
      {
         // Display a MsgBox asking the user to save changes or abort.
         if ( MessageBox::Show( "Do you want to save changes to your text?", "My Application", MessageBoxButtons::YesNo ) == ::DialogResult::Yes )
         {
            // Cancel the Closing event from closing the form.
            e->Cancel = true;

            // Call method to save file...
         }
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
