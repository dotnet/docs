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
   System::Windows::Forms::RichTextBox^ richTextBox1;

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
      this->button1->Location = System::Drawing::Point( 200, 224 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      //
      // richTextBox1
      //
      this->richTextBox1->Location = System::Drawing::Point( 16, 16 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 248, 192 );
      this->richTextBox1->TabIndex = 1;
      this->richTextBox1->Text = "Alpha Bravo Charlie Delta Echo";

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->richTextBox1,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   // <Snippet1>
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      array<Char>^temp1 = {'D','e','l','t','a'};
      MessageBox::Show( FindMyText( temp1 ).ToString() );
   }

public:
   int FindMyText( array<Char>^text )
   {
      // Initialize the return value to false by default.
      int returnValue = -1;

      // Ensure that a search string has been specified and a valid start point.
      if ( text->Length > 0 )
      {
         // Obtain the location of the first character found in the control
         // that matches any of the characters in the char array.
         int indexToText = richTextBox1->Find( text );

         // Determine whether the text was found in richTextBox1.
         if ( indexToText >= 0 )
         {
            // Return the location of the character.
            returnValue = indexToText;
         }
      }

      return returnValue;
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
