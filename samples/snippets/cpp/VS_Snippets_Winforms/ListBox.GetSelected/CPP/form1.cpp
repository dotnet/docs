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
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // listBox1
      // 
      array<Object^>^temp0 = {"Alpha","Bravo","Charlie","Delta","Echo","Foxtro","Golf","Hotel","Igloo","Java","Koala","Lima","Mama"};
      this->listBox1->Items->AddRange( temp0 );
      this->listBox1->Location = System::Drawing::Point( 56, 40 );
      this->listBox1->Name = "listBox1";
      this->listBox1->SelectionMode = System::Windows::Forms::SelectionMode::None;
      this->listBox1->Size = System::Drawing::Size( 200, 82 );
      this->listBox1->TabIndex = 0;
      this->listBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::listBox1_MouseDown );

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 264, 72 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 376, 254 );
      array<System::Windows::Forms::Control^>^temp1 = {this->button1,this->listBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   //<Snippet1>
private:
   void InitializeMyListBox()
   {
      // Add items to the ListBox.
      listBox1->Items->Add( "A" );
      listBox1->Items->Add( "C" );
      listBox1->Items->Add( "E" );
      listBox1->Items->Add( "F" );
      listBox1->Items->Add( "G" );
      listBox1->Items->Add( "D" );
      listBox1->Items->Add( "B" );

      // Sort all items added previously.
      listBox1->Sorted = true;

      // Set the SelectionMode to select multiple items.
      listBox1->SelectionMode = SelectionMode::MultiExtended;

      // Select three initial items from the list.
      listBox1->SetSelected( 0, true );
      listBox1->SetSelected( 2, true );
      listBox1->SetSelected( 4, true );

      // Force the ListBox to scroll back to the top of the list.
      listBox1->TopIndex = 0;
   }

   void InvertMySelection()
   {
      // Loop through all items the ListBox.
      for ( int x = 0; x < listBox1->Items->Count; x++ )
      {
         // Select all items that are not selected,
         // deselect all items that are selected.
         listBox1->SetSelected( x,  !listBox1->GetSelected( x ) );
      }
      listBox1->TopIndex = 0;
   }
   //</Snippet1>

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      InvertMySelection();
   }

   void listBox1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ /*e*/ ){}

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      listBox1->Items->Clear();
      this->InitializeMyListBox();
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
