// System::Windows::Forms::Control::StyleChanged

/*
The following example demonstrates the 'StyleChanged' event
of 'Control' class. This example has the style of the form
set when the form is loaded. This setting of the style
raises the 'StyleChanged' event. The event handler associated
with the 'StyleChanged' event pops a message box indicating
the same.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class MyForm: public Form
{
private:
   System::Windows::Forms::Button^ myButton1;
   System::ComponentModel::Container^ components;

public:
   MyForm()
   {
      components = nullptr;
      InitializeComponent();
   }

public:
   ~MyForm()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      this->myButton1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      // Set the properties of the 'myButton1'.
      this->myButton1->Location = System::Drawing::Point( 24, 8 );
      this->myButton1->Name = "myButton1";
      this->myButton1->Size = System::Drawing::Size( 192, 48 );
      this->myButton1->TabIndex = 0;
      this->myButton1->Text = "button1";
      this->myButton1->Click += gcnew System::EventHandler( this, &MyForm::MyButton1_Click );
      
      // Set the properties of the 'MyForm'.
      this->ClientSize = System::Drawing::Size( 248, 61 );
      array<System::Windows::Forms::Control^>^myFormControls = {this->myButton1};
      this->Controls->AddRange( myFormControls );
      this->Name = "MyForm";
      this->Text = "MyForm";
      this->Load += gcnew EventHandler( this, &MyForm::MyForm_Load );
      RegisterEventHandler();
      this->ResumeLayout( false );
   }

   void MyButton1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "The 'Control' has been clicked" );
   }

   // <Snippet1>
private:
   // Set the 'FixedHeight' and 'FixedWidth' styles to false.
   void MyForm_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      this->SetStyle( ControlStyles::FixedHeight, false );
      this->SetStyle( ControlStyles::FixedWidth, false );
   }

   void RegisterEventHandler()
   {
      this->StyleChanged += gcnew EventHandler( this, &MyForm::MyForm_StyleChanged );
   }

   // Handle the 'StyleChanged' event for the 'Form'.
   void MyForm_StyleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "The style releated to the 'Form' has been changed" );
   }
   // </Snippet1>
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
