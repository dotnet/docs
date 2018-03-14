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
   System::Windows::Forms::ListBox^ listBox1;
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
      components = nullptr;
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
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      //
      // listBox1
      //
      array<Object^>^temp0 = {"Alpha","Bravo","Charlie","Delta","Echo"};
      this->listBox1->Items->AddRange( temp0 );
      this->listBox1->Location = System::Drawing::Point( 24, 32 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 224, 108 );
      this->listBox1->TabIndex = 0;

      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 264, 32 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 104, 24 );
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 504, 422 );
      array<System::Windows::Forms::Control^>^temp1 = {this->button1,this->listBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      FindMyString( "Charlie" );
   }

   //<Snippet1>
private:
   void FindMyString( String^ searchString )
   {
      // Ensure we have a proper string to search for.
      if ( searchString != String::Empty )
      {
         // Find the item in the list and store the index to the item.
         int index = listBox1->FindString( searchString );

         // Determine if a valid index is returned. Select the item if it is valid.
         if ( index != -1 )
                  listBox1->SetSelected( index, true );
         else
                  MessageBox::Show( "The search string did not match any items in the ListBox" );
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
