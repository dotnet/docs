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
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::TextBox^ textBox1;

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
      this->button1 = gcnew System::Windows::Forms::Button;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();

      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 176, 32 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 80, 32 );
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Enter += gcnew System::EventHandler( this, &Form1::button1_Enter );

      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 48, 104 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 176, 20 );
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "textBox1";
      this->textBox1->Leave += gcnew System::EventHandler( this, &Form1::textBox1_Leave );
      this->textBox1->Enter += gcnew System::EventHandler( this, &Form1::textBox1_Enter );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->textBox1,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Enter( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

   //<Snippet1>
private:
   void textBox1_Enter( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // If the TextBox contains text, change its foreground and background colors.
      if ( textBox1->Text != String::Empty )
      {
         textBox1->ForeColor = Color::Red;
         textBox1->BackColor = Color::Black;

         // Move the selection pointer to the end of the text of the control.
         textBox1->Select(textBox1->Text->Length,0);
      }
   }

   void textBox1_Leave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Reset the colors and selection of the TextBox after focus is lost.
      textBox1->ForeColor = Color::Black;
      textBox1->BackColor = Color::White;
      textBox1->Select(0,0);
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
