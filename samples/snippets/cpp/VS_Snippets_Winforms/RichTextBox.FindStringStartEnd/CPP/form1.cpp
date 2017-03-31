

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
   System::Windows::Forms::Button^ button1;

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
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // richTextBox1
      // 
      this->richTextBox1->Location = System::Drawing::Point( 16, 16 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 256, 160 );
      this->richTextBox1->TabIndex = 0;
      this->richTextBox1->Text = "Alpha Bravo Charlie Delta Echo Foxtrot Golf";

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 200, 184 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 280, 214 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->richTextBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( FindMyText( "Golf", 44, -1 ).ToString() );
   }

   //<Snippet1>
public:
   int FindMyText( String^ searchText, int searchStart, int searchEnd )
   {
      // Initialize the return value to false by default.
      int returnValue = -1;

      // Ensure that a search string and a valid starting point are specified.
      if ( searchText->Length > 0 && searchStart >= 0 )
      {
         // Ensure that a valid ending value is provided.
         if ( searchEnd > searchStart || searchEnd == -1 )
         {
            // Obtain the location of the search string in richTextBox1.
            int indexToText = richTextBox1->Find( searchText, searchStart, searchEnd, RichTextBoxFinds::MatchCase );

            // Determine whether the text was found in richTextBox1.
            if ( indexToText >= 0 )
            {
               // Return the index to the specified search text.
               returnValue = indexToText;
            }
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
