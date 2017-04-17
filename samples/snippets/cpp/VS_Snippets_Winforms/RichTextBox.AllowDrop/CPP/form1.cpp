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
   System::Windows::Forms::RichTextBox^ richTextBox1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

   //
   // Required for Windows Form Designer supports
   //

   //<Snippet1>
public:
   Form1()
   {
      InitializeComponent();
      
      // Sets the control to allow drops, and then adds the necessary event handlers.
      this->richTextBox1->AllowDrop = true;
   }

private:
   void listBox1_MouseDown( Object^ sender, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determines which item was selected.
      ListBox^ lb = (dynamic_cast<ListBox^>(sender));
      Point pt = Point(e->X,e->Y);

      //Retrieve the item at the specified location within the ListBox.
      int index = lb->IndexFromPoint( pt );

      // Starts a drag-and-drop operation.
      if ( index >= 0 )
      {
         // Retrieve the selected item text to drag into the RichTextBox.
         lb->DoDragDrop( lb->Items[ index ]->ToString(), DragDropEffects::Copy );
      }
   }

   void richTextBox1_DragEnter( Object^ /*sender*/, DragEventArgs^ e )
   {
      // If the data is text, copy the data to the RichTextBox control.
      if ( e->Data->GetDataPresent( "Text" ) )
            e->Effect = DragDropEffects::Copy;
   }

   void richTextBox1_DragDrop( Object^ /*sender*/, DragEventArgs^ e )
   {
      // Paste the text into the RichTextBox where at selection location.
      richTextBox1->SelectedText = e->Data->GetData( "System.String", true )->ToString();
   }
   //</Snippet1>

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
      this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->SuspendLayout();

      // 
      // listBox1
      // 
      array<Object^>^temp1 = {"Alpha","Bravo","Charlie","Delta","Echo","Foxtrot"};
      this->listBox1->Items->AddRange( temp1 );
      this->listBox1->Location = System::Drawing::Point( 16, 16 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 208, 238 );
      this->listBox1->TabIndex = 0;
      this->listBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::listBox1_MouseDown );

      // 
      // richTextBox1
      // 
      this->richTextBox1->Location = System::Drawing::Point( 240, 16 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 208, 240 );
      this->richTextBox1->TabIndex = 1;
      this->richTextBox1->Text = "";
      this->richTextBox1->DragDrop += gcnew System::Windows::Forms::DragEventHandler( this, &Form1::richTextBox1_DragDrop );
      this->richTextBox1->DragEnter += gcnew System::Windows::Forms::DragEventHandler( this, &Form1::richTextBox1_DragEnter );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 464, 273 );
      array<System::Windows::Forms::Control^>^temp2 = {this->richTextBox1,this->listBox1};
      this->Controls->AddRange( temp2 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
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
