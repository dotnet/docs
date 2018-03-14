#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
private:
   RichTextBox^ richTextBox1;

public:
   Form1()
   {
      richTextBox1 = gcnew RichTextBox;

      richTextBox1->LinkClicked += gcnew LinkClickedEventHandler(
          this, &Form1::Link_Clicked );
      richTextBox1->SelectedText = "To see Microsoft go to www.microsoft.com";
      richTextBox1->Location = System::Drawing::Point( 10, 10 );
      richTextBox1->Size = System::Drawing::Size( 100, 100 );

      this->Controls->Add( richTextBox1 );
   }

   // <Snippet1>
private:
   void Link_Clicked( Object^ sender, System::Windows::Forms::LinkClickedEventArgs^ e )
   {
      System::Diagnostics::Process::Start( e->LinkText );
   }
   // </Snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>
[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
