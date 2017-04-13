

// <Snippet1>
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
using namespace System::IO;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::CheckedListBox^ checkedListBox1;
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::ListBox^ listBox1;
   System::Windows::Forms::Button^ button3;
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      InitializeComponent();
      
      // Sets up the initial objects in the CheckedListBox.
      array<String^>^myFruit = {"Apples","Oranges","Tomato"};
      checkedListBox1->Items->AddRange( myFruit );
      
      // Changes the selection mode from double-click to single click.
      checkedListBox1->CheckOnClick = true;
   }

public:
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->checkedListBox1 = gcnew System::Windows::Forms::CheckedListBox;
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->button3 = gcnew System::Windows::Forms::Button;
      this->textBox1->Location = System::Drawing::Point( 144, 64 );
      this->textBox1->Size = System::Drawing::Size( 128, 20 );
      this->textBox1->TabIndex = 1;
      this->textBox1->TextChanged += gcnew System::EventHandler( this, &Form1::textBox1_TextChanged );
      this->checkedListBox1->Location = System::Drawing::Point( 16, 64 );
      this->checkedListBox1->Size = System::Drawing::Size( 120, 184 );
      this->checkedListBox1->TabIndex = 0;
      this->checkedListBox1->ItemCheck += gcnew System::Windows::Forms::ItemCheckEventHandler( this, &Form1::checkedListBox1_ItemCheck );
      this->listBox1->Location = System::Drawing::Point( 408, 64 );
      this->listBox1->Size = System::Drawing::Size( 128, 186 );
      this->listBox1->TabIndex = 3;
      this->button1->Enabled = false;
      this->button1->Location = System::Drawing::Point( 144, 104 );
      this->button1->Size = System::Drawing::Size( 104, 32 );
      this->button1->TabIndex = 2;
      this->button1->Text = "Add Fruit";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      this->button2->Enabled = false;
      this->button2->Location = System::Drawing::Point( 288, 64 );
      this->button2->Size = System::Drawing::Size( 104, 32 );
      this->button2->TabIndex = 2;
      this->button2->Text = "Show Order";
      this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );
      this->button3->Enabled = false;
      this->button3->Location = System::Drawing::Point( 288, 104 );
      this->button3->Size = System::Drawing::Size( 104, 32 );
      this->button3->TabIndex = 2;
      this->button3->Text = "Save Order";
      this->button3->Click += gcnew System::EventHandler( this, &Form1::button3_Click );
      this->ClientSize = System::Drawing::Size( 563, 273 );
      array<System::Windows::Forms::Control^>^temp0 = {this->listBox1,this->button3,this->button2,this->button1,this->textBox1,this->checkedListBox1};
      this->Controls->AddRange( temp0 );
      this->Text = "Fruit Order";
   }

   // Adds the string if the text box has data in it.
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if (  !textBox1->Text->Equals( "" ) )
      {
         if ( checkedListBox1->CheckedItems->Contains( textBox1->Text ) == false )
                  checkedListBox1->Items->Add( textBox1->Text, CheckState::Checked );
         textBox1->Text = "";
      }
   }

   // Activates or deactivates the Add button.
   void textBox1_TextChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( textBox1->Text->Equals( "" ) )
      {
         button1->Enabled = false;
      }
      else
      {
         button1->Enabled = true;
      }
   }

   // Moves the checked items from the CheckedListBox to the listBox.
   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      listBox1->Items->Clear();
      button3->Enabled = false;
      for ( int i = 0; i < checkedListBox1->CheckedItems->Count; i++ )
      {
         listBox1->Items->Add( checkedListBox1->CheckedItems[ i ] );

      }
      if ( listBox1->Items->Count > 0 )
            button3->Enabled = true;
   }

   // Activates the move button if there are checked items.
   void checkedListBox1_ItemCheck( Object^ /*sender*/, ItemCheckEventArgs^ e )
   {
      if ( e->NewValue == CheckState::Unchecked )
      {
         if ( checkedListBox1->CheckedItems->Count == 1 )
         {
            button2->Enabled = false;
         }
      }
      else
      {
         button2->Enabled = true;
      }
   }

   // Saves the items to a file.
   void button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Insert code to save a file.
      listBox1->Items->Clear();
      IEnumerator^ myEnumerator;
      myEnumerator = checkedListBox1->CheckedIndices->GetEnumerator();
      int y;
      while ( myEnumerator->MoveNext() != false )
      {
         y = safe_cast<Int32>(myEnumerator->Current);
         checkedListBox1->SetItemChecked( y, false );
      }

      button3->Enabled = false;
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
// </Snippet1>
