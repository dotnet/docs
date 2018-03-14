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

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::GroupBox^ groupBox1;
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
      this->groupBox1 = gcnew System::Windows::Forms::GroupBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->groupBox1->SuspendLayout();
      this->SuspendLayout();

      // 
      // groupBox1
      // 
      array<System::Windows::Forms::Control^>^temp0 = {this->button1};
      this->groupBox1->Controls->AddRange( temp0 );
      this->groupBox1->Location = System::Drawing::Point( 32, 24 );
      this->groupBox1->Name = "groupBox1";
      this->groupBox1->Size = System::Drawing::Size( 240, 184 );
      this->groupBox1->TabIndex = 0;
      this->groupBox1->TabStop = false;
      this->groupBox1->Text = "groupBox1";

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 144, 48 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp1 = {this->groupBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->groupBox1->ResumeLayout( false );
      this->ResumeLayout( false );
   }

   //<Snippet1>
   // This example uses the Parent property and the Find method of Control to set
   // properties on the parent control of a Button and its Form. The example assumes
   // that a Button control named button1 is located within a GroupBox control. The 
   // example also assumes that the Click event of the Button control is connected to
   // the event handler method defined in the example.
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Get the control the Button control is located in. In this case a GroupBox.
      Control^ control = button1->Parent;
      
      // Set the text and backcolor of the parent control.
      control->Text = "My Groupbox";
      control->BackColor = Color::Blue;
      
      // Get the form that the Button control is contained within.
      Form^ myForm = button1->FindForm();
      
      // Set the text and color of the form containing the Button.
      myForm->Text = "The Form of My Control";
      myForm->BackColor = Color::Red;
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
