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
      this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->SuspendLayout();

      // 
      // richTextBox1
      // 
      this->richTextBox1->Location = System::Drawing::Point( 16, 16 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 408, 232 );
      this->richTextBox1->TabIndex = 0;
      this->richTextBox1->Text = "There once was a brown man from Nantucket...";
      this->richTextBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::richTextBox1_MouseDown );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 440, 270 );
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
      // Declare the string to search for in the control.
      String^ searchString = "brown";

      // Determine whether the user clicks the left mouse button and whether it is a double click.
      if ( e->Clicks == 1 && e->Button == ::MouseButtons::Left )
      {
         // Obtain the character index where the user clicks on the control.
         int positionToSearch = richTextBox1->GetCharIndexFromPosition( Point(e->X,e->Y) );

         // Search for the search string text within the control from the point the user clicked.
         int textLocation = richTextBox1->Find( searchString, positionToSearch, RichTextBoxFinds::None );

         // If the search string is found (value greater than -1), display the index the string was found at.
         if ( textLocation >= 0 )
            MessageBox::Show( String::Format( "The search string was found at character index {0}.", textLocation ) ); // Display a message box alerting the user that the text was not found.
         else
            MessageBox::Show( "The search string was not found within the text of the control." );
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
