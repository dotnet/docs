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
      array<Object^>^temp0 = {"Alpha","Bravo","Charlie","Delta","Echo","Foxtrot","Golf","Hotel"};
      this->listBox1->Items->AddRange( temp0 );
      this->listBox1->Location = System::Drawing::Point( 64, 48 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 216, 69 );
      this->listBox1->TabIndex = 0;

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 312, 64 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 88, 24 );
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 448, 414 );
      array<System::Windows::Forms::Control^>^temp1 = {this->button1,this->listBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      RemoveTopItems();
   }

   //<Snippet1>
private:
   void RemoveTopItems()
   {
      // Determine if the currently selected item in the ListBox 
      // is the item displayed at the top in the ListBox.
      if ( listBox1->TopIndex != listBox1->SelectedIndex )

      // Make the currently selected item the top item in the ListBox.
      listBox1->TopIndex = listBox1->SelectedIndex;

      // Remove all items before the top item in the ListBox.
      for ( int x = (listBox1->SelectedIndex - 1); x >= 0; x-- )
      {
         listBox1->Items->RemoveAt( x );
      }

      // Clear all selections in the ListBox.
      listBox1->ClearSelected();
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
