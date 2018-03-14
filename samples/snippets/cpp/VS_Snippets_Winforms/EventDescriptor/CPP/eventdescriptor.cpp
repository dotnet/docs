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

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

protected:

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
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";

      // 
      // textBox1
      // 
      this->textBox1->Location = System::Drawing::Point( 8, 96 );
      this->textBox1->Multiline = true;
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 608, 160 );
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "textBox1";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 632, 273 );
      array<System::Windows::Forms::Control^>^temp0 = {this->textBox1,this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      //<snippet1>
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );

      // Displays each event's information in the collection in a text box.
      for each (EventDescriptor^ myEvent in events) {
          textBox1->Text += myEvent->Category + '\n';
          textBox1->Text += myEvent->Description + '\n';
          textBox1->Text += myEvent->DisplayName + '\n';
      }
      //</snippet1>
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
