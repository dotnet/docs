#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

public ref class MyForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;
   System::ComponentModel::Container^ components;

public:
   MyForm()
   {
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
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // button1
      //
      this->button1->Location = System::Drawing::Point( 48, 56 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";

      // 
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^controlArray = {this->button1};
      this->Controls->AddRange( controlArray );
      this->Name = "MyForm";
      this->Text = "MyForm";
      this->Layout += gcnew System::Windows::Forms::LayoutEventHandler( this, &MyForm::MyForm_Layout );
      this->ResumeLayout( false );
   }

   // <snippet1>
private:
   void MyForm_Layout( Object^ /*sender*/, System::Windows::Forms::LayoutEventArgs^ /*e*/ )
   {
      // Center the Form on the user's screen everytime it requires a Layout.
      this->SetBounds( (Screen::GetBounds( this ).Width / 2) - (this->Width / 2), (Screen::GetBounds( this ).Height / 2) - (this->Height / 2), this->Width, this->Height, BoundsSpecified::Location );
   }
   // </snippet1>
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
