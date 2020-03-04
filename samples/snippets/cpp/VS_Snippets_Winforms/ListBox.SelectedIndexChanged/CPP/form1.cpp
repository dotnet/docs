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
   System::Windows::Forms::ListBox^ listBox2;

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
      this->listBox2 = gcnew System::Windows::Forms::ListBox;
      this->SuspendLayout();

      // 
      // listBox1
      // 
      array<Object^>^temp0 = {"A","B","C","D","E","F","G","H","I","J","K"};
      this->listBox1->Items->AddRange( temp0 );
      this->listBox1->Location = System::Drawing::Point( 40, 32 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 136, 95 );
      this->listBox1->TabIndex = 0;
      this->listBox1->SelectedIndexChanged += gcnew System::EventHandler( this, &Form1::listBox1_SelectedIndexChanged );

      // 
      // listBox2
      // 
      array<Object^>^temp1 = {"D","A","B","E","C","F","H","G","K","I","J"};
      this->listBox2->Items->AddRange( temp1 );
      this->listBox2->Location = System::Drawing::Point( 200, 32 );
      this->listBox2->Name = "listBox2";
      this->listBox2->Size = System::Drawing::Size( 136, 95 );
      this->listBox2->TabIndex = 2;

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 424, 266 );
      array<System::Windows::Forms::Control^>^temp2 = {this->listBox2,this->listBox1};
      this->Controls->AddRange( temp2 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<Snippet1>
private:
   void listBox1_SelectedIndexChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Get the currently selected item in the ListBox.
      String^ curItem = listBox1->SelectedItem->ToString();

      // Find the string in ListBox2.
      int index = listBox2->FindString( curItem );

      // If the item was not found in ListBox 2 display a message box,
      //  otherwise select it in ListBox2.
      if ( index == -1 )
            MessageBox::Show( "Item is not available in ListBox2" );
      else
            listBox2->SetSelected( index, true );
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
