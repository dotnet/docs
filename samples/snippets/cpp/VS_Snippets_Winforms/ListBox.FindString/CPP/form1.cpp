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
   System::Windows::Forms::TextBox^ textBox1;
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

   //  #region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 208, 216 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 152, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "";

      //
      // listBox1
      //
      array<Object^>^temp0 = {"Alpha","Bravo","Charlie","Delta","Echo","Foxtrot","Alpha2","Alpha3","Bravo2","Charlie2","Delta3","Echo2","Delta2","Foxtrot2"};
      this->listBox1->Items->AddRange( temp0 );
      this->listBox1->Location = System::Drawing::Point( 192, 32 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 208, 147 );
      this->listBox1->TabIndex = 1;

      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 368, 216 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 2;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 496, 350 );
      array<System::Windows::Forms::Control^>^temp1 = {this->button1,this->listBox1,this->textBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   //  #endregion
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      FindAllOfMyString( textBox1->Text );
   }

   //<Snippet1>
private:
   void FindAllOfMyString( String^ searchString )
   {
      // Set the SelectionMode property of the ListBox to select multiple items.
      listBox1->SelectionMode = SelectionMode::MultiExtended;

      // Set our intial index variable to -1.
      int x = -1;

      // If the search string is empty exit.
      if ( searchString->Length != 0 )
      {
         // Loop through and find each item that matches the search string.
         do
         {
            // Retrieve the item based on the previous index found. Starts with -1 which searches start.
            x = listBox1->FindString( searchString, x );

            // If no item is found that matches exit.
            if ( x != -1 )
            {
               // Since the FindString loops infinitely, determine if we found first item again and exit.
               if ( listBox1->SelectedIndices->Count > 0 )
               {
                  if ( x == listBox1->SelectedIndices[ 0 ] )
                                    return;
               }

               // Select the item in the ListBox once it is found.
               listBox1->SetSelected( x, true );
            }
         }
         while ( x != -1 );
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
