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
      richTextBox1->Clear();
      
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
      this->button1->Location = System::Drawing::Point( 336, 72 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 3;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // richTextBox1
      // 
      this->richTextBox1->Location = System::Drawing::Point( 24, 24 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 296, 168 );
      this->richTextBox1->TabIndex = 2;
      this->richTextBox1->Text = "richTextBox1";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 440, 222 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->richTextBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "C#";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ModifySelectedText();
   }

   //<Snippet1>
private:
   void ModifySelectedText()
   {
      // Determine if text is selected in the control.
      if ( richTextBox1->SelectionLength > 0 )
      {
         // Set the color of the selected text in the control.
         richTextBox1->SelectionColor = Color::Red;

         // Set the font of the selected text to bold and underlined.
         richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Arial",10,static_cast<FontStyle>(FontStyle::Bold | FontStyle::Underline) );

         // Protect the selected text from modification.
         richTextBox1->SelectionProtected = true;
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
