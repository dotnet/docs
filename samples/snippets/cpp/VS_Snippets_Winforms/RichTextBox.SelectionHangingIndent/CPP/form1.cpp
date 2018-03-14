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
      this->richTextBox1->Location = System::Drawing::Point( 8, 8 );
      this->richTextBox1->Name = "richTextBox1";
      this->richTextBox1->Size = System::Drawing::Size( 400, 168 );
      this->richTextBox1->TabIndex = 0;
      this->richTextBox1->Text = "richTextBox1";

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 312, 192 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 416, 382 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->richTextBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      WriteIndentedTextToRichTextBox();
   }

   //<Snippet1>
private:
   void WriteIndentedTextToRichTextBox()
   {
      // Clear all text from the RichTextBox;
      richTextBox1->Clear();

      // Specify a 20 pixel hanging indent in all paragraphs.
      richTextBox1->SelectionHangingIndent = 20;

      // Set the font for the text.
      richTextBox1->Font = gcnew System::Drawing::Font( "Lucinda Console",12 );

      // Set the text within the control.
      richTextBox1->SelectedText = "This text contains a hanging indent. The first sentence of the paragraph is spaced normally.";
      richTextBox1->SelectedText = "All subsequent lines of text are indented based on the value of SelectionHangingIndent.";
      richTextBox1->SelectedText = "After this paragraph the indent is returned to normal spacing.\n";
      richTextBox1->SelectedText = "Since this is a new paragraph the indent is also applied to this paragraph.";
      richTextBox1->SelectedText = "All subsequent lines of text are indented based on the value of SelectionHangingIndent.";
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
