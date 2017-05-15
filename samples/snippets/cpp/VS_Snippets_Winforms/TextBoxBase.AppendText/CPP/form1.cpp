

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
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::TextBox^ textBox2;
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
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->textBox2 = gcnew System::Windows::Forms::TextBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      // 
      // textBox1
      // 
      this->textBox1->Location = System::Drawing::Point( 24, 24 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 144, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "textBox1";
      
      // 
      // textBox2
      // 
      this->textBox2->Location = System::Drawing::Point( 24, 56 );
      this->textBox2->Name = "textBox2";
      this->textBox2->Size = System::Drawing::Size( 144, 20 );
      this->textBox2->TabIndex = 1;
      this->textBox2->Text = "textBox2";
      
      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 208, 40 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 2;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->textBox2,this->textBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      AppendTextBox1Text();
   }

   //<Snippet1>
   void AppendTextBox1Text()
   {
      // Determine if text is selected in textBox1.
      if ( textBox1->SelectionLength == 0 )

      // No selection made, return.
      return;

      // Determine if the text being appended to textBox2 exceeds the MaxLength property.
      if ( (textBox1->SelectedText->Length + textBox2->TextLength) > textBox2->MaxLength )
            MessageBox::Show( "The text to paste in is larger than the maximum number of characters allowed" ); // Append the text from textBox1 into textBox2.
      else
            textBox2->AppendText( textBox1->SelectedText );
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
