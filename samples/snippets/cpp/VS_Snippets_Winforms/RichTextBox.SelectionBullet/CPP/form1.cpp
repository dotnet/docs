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
   System::Windows::Forms::RichTextBox^ richTextBox1;
   System::Windows::Forms::Button^ button1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;

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
      array<System::Windows::Forms::Control^>^formControls = {this->button1,this->richTextBox1};
      this->Controls->AddRange( formControls );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      WriteTextToRichTextBox();
   }

   //<Snippet1>
private:
   void WriteTextToRichTextBox()
   {
      // Clear all text from the RichTextBox;
      richTextBox1->Clear();

      // Set the font for the opening text to a larger Arial font;
      richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Arial",16 );

      // Assign the introduction text to the RichTextBox control.
      richTextBox1->SelectedText = "The following is a list of bulleted items: \n";

      // Set the Font for the first item to a smaller size Arial font.
      richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Arial",12 );

      // Specify that the following items are to be added to a bulleted list.
      richTextBox1->SelectionBullet = true;

      // Set the color of the item text.
      richTextBox1->SelectionColor = Color::Red;

      // Assign the text to the bulleted item.
      richTextBox1->SelectedText = "Apples \n";

      // Apply same font since font settings do not carry to next line.
      richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Arial",12 );
      richTextBox1->SelectionColor = Color::Orange;
      richTextBox1->SelectedText = "Oranges \n";
      richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Arial",12 );
      richTextBox1->SelectionColor = Color::Purple;
      richTextBox1->SelectedText = "Grapes \n";

      // End the bulleted list.
      richTextBox1->SelectionBullet = false;

      // Specify the font size and string for text displayed below bulleted list.
      richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Arial",16 );
      richTextBox1->SelectedText = "Bulleted Text Complete!";
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
