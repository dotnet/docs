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
private:
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

protected:

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
      this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->SuspendLayout();

      // 
      // richTextBox1
      // 
      this->richTextBox1->Location = System::Drawing::Point( 24, 24 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 320, 264 );
      this->richTextBox1->TabIndex = 0;
      this->richTextBox1->Text = "There once was a man from Nantucket.";
      this->richTextBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::richTextBox1_MouseDown );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 368, 310 );
      array<System::Windows::Forms::Control^>^temp0 = {this->richTextBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<Snippet1>
private:
   void richTextBox1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determine which mouse button is clicked.
      if ( e->Button == ::MouseButtons::Left )
      {
         // Obtain the character at which the mouse cursor was clicked at.
         Char tempChar = richTextBox1->GetCharFromPosition( Point(e->X,e->Y) );

         // Determine whether the character is an empty space.
         if (  !tempChar.ToString()->Equals( " " ) )

         // Display the character in a message box.
         MessageBox::Show( String::Format( "The character at the specified position is {0}.", tempChar ) );
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
