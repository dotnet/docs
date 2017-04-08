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
internal:
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::RichTextBox^ richTextBox1;

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
      this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->SuspendLayout();

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 336, 96 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 5;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // richTextBox1
      // 
      this->richTextBox1->Location = System::Drawing::Point( 16, 48 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 296, 168 );
      this->richTextBox1->TabIndex = 4;
      this->richTextBox1->Text = "richTextBox1";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 424, 254 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->richTextBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      richTextBox1->Clear();
      richTextBox1->AppendText( "This text is being added to the RichTextBox control to protect" );
      ProtectMySelectedText();
   }

   //<Snippet1>
private:
   void ProtectMySelectedText()
   {
      // Determine if the selected text in the control contains the word "RichTextBox".
      if (  !richTextBox1->SelectedText->Equals( "RichTextBox" ) )
      {
         // Search for the word RichTextBox in the control.
         if ( richTextBox1->Find( "RichTextBox", RichTextBoxFinds::WholeWord ) == -1 )
         {
            //Alert the user that the word was not foun and return.
            MessageBox::Show( "The text \"RichTextBox\" was not found!" );
            return;
         }
      }

      // Protect the selected text in the control from being altered.
      richTextBox1->SelectionProtected = true;
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
