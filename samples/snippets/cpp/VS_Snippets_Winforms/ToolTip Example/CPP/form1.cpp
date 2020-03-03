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
   System::Windows::Forms::CheckBox^ checkBox1;
   System::Windows::Forms::Button^ button1;

public:
   /// <summary>
   /// Required designer variable.
   /// </summary>
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

private:
   /// <summary>
   /// Clean up any resources being used.
   /// </summary>

   #pragma region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->button1 = gcnew System::Windows::Forms::Button;
      this->checkBox1 = gcnew System::Windows::Forms::CheckBox;
      this->SuspendLayout();
      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 200, 20 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 84, 24 );
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      // 
      // checkBox1
      // 
      this->checkBox1->Location = System::Drawing::Point( 204, 60 );
      this->checkBox1->Name = "checkBox1";
      this->checkBox1->TabIndex = 0;
      this->checkBox1->Text = "checkBox1";
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^ temp0 = { this->button1, this->checkBox1 };
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }
   #pragma endregion

   //<snippet1>
   // This example assumes that the Form_Load event handling method
   // is connected to the Load event of the form.
   void Form1_Load( Object^ sender, System::EventArgs^ e )
   {
      // Create the ToolTip and associate with the Form container.
      ToolTip^ toolTip1 = gcnew ToolTip;
      
      // Set up the delays for the ToolTip.
      toolTip1->AutoPopDelay = 5000;
      toolTip1->InitialDelay = 1000;
      toolTip1->ReshowDelay = 500;
      // Force the ToolTip text to be displayed whether or not the form is active.
      toolTip1->ShowAlways = true;
      
      // Set up the ToolTip text for the Button and Checkbox.
      toolTip1->SetToolTip( this->button1, "My button1" );
      toolTip1->SetToolTip( this->checkBox1, "My checkBox1" );
   }
   //</snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
