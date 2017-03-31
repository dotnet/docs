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

public:
   Form1()
   {
      components = nullptr;

      //
      // Required for Windows Form Designer supports
      //
      InitializeComponent();

      // Sets the control to allow drops, and then adds the necessary event handlers.
      this->richTextBox1->AllowDrop = true;
      this->richTextBox1->DragEnter += gcnew DragEventHandler( this, &Form1::richTextBox1_DragEnter );
      this->richTextBox1->DragDrop += gcnew DragEventHandler( this, &Form1::richTextBox1_DragDrop );
      this->listBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::listBox1_MouseDown );
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );

      // Add code here to populate the ListBox1 with paths to text files.
   }

   //<snippet1>
private:
   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Sets the AllowDrop property so that data can be dragged onto the control.
      richTextBox1->AllowDrop = true;

      // Add code here to populate the ListBox1 with paths to text files.
   }

   void listBox1_MouseDown( Object^ sender, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determines which item was selected.
      ListBox^ lb = (dynamic_cast<ListBox^>(sender));
      Point pt = Point(e->X,e->Y);
      int index = lb->IndexFromPoint( pt );

      // Starts a drag-and-drop operation with that item.
      if ( index >= 0 )
      {
         lb->DoDragDrop( lb->Items[ index ], DragDropEffects::Link );
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
      // Loads the file into the control.
      richTextBox1->LoadFile( dynamic_cast<String^>(e->Data->GetData( "Text" )), System::Windows::Forms::RichTextBoxStreamType::RichText );
   }
   //</snippet1>

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
      this->listBox1->Location = System::Drawing::Point( 256, 48 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 120, 95 );
      this->listBox1->TabIndex = 0;

      //
      // richTextBox1
      //
      this->richTextBox1->Location = System::Drawing::Point( 64, 40 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->TabIndex = 1;
      this->richTextBox1->Text = "richTextBox1";

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 464, 273 );
      array<System::Windows::Forms::Control^>^formControls = {this->richTextBox1,this->listBox1};
      this->Controls->AddRange( formControls );
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
