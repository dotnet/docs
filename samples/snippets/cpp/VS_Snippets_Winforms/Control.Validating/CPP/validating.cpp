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
using namespace System::Runtime::InteropServices;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::ErrorProvider^ errorProvider1;



private:
   void InitializeComponent()
   {
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->errorProvider1 = gcnew System::Windows::Forms::ErrorProvider;
      this->textBox1->Location = System::Drawing::Point( 16, 16 );
      this->textBox1->Size = System::Drawing::Size( 216, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "textBox1";
      this->textBox1->Validating += gcnew System::ComponentModel::CancelEventHandler( this, &Form1::textBox1_Validating );
      this->textBox1->Validated += gcnew System::EventHandler( this, &Form1::textBox1_Validated );
      this->button1->Location = System::Drawing::Point( 208, 240 );
      this->button1->TabIndex = 2;
      this->button1->Text = "button1";
      this->button2->Location = System::Drawing::Point( 108, 240 );
      this->button2->TabIndex = 1;
      this->button2->Text = "Non-Validating";
      this->errorProvider1->DataMember = nullptr;
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^ controlArray = {this->textBox1,this->button1, this->button2};
      this->Controls->AddRange( controlArray );
      this->Text = "Form1";
   }

//<Snippet2>
public:
   Form1()
   {
      InitializeComponent();    
      //Set button2 to be non-validating.
      this->button2->CausesValidation = false;
   }

   //  <Snippet1>
private:
   void textBox1_Validating( Object^ sender, System::ComponentModel::CancelEventArgs^ e )
   {
      String^ errorMsg;
      if ( !ValidEmailAddress( textBox1->Text, &errorMsg ) )
      {
         // Cancel the event and select the text to be corrected by the user.
         e->Cancel = true;
         textBox1->Select( 0, textBox1->Text->Length );
         
         // Set the ErrorProvider error with the text to display.
         this->errorProvider1->SetError( textBox1, errorMsg );
      }
   }

   void textBox1_Validated( Object^ sender, System::EventArgs^ e )
   {
      // If all conditions have been met, clear the ErrorProvider of errors.
      errorProvider1->SetError( textBox1, "" );
   }

public:
   bool ValidEmailAddress( String^ emailAddress, [Out]interior_ptr<String^> errorMessage )
   {
      // Confirm that the e-mail address String* is not empty.
      if ( emailAddress->Length == 0 )
      {
         *errorMessage = "e-mail address is required.";
         return false;
      }

      // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
      if ( emailAddress->IndexOf( "@" ) > -1 )
      {
         if ( emailAddress->IndexOf( ".", emailAddress->IndexOf( "@" ) ) > emailAddress->IndexOf( "@" ) )
         {
            *errorMessage = "";
            return true;
         }
      }

      *errorMessage = "e-mail address must be valid e-mail address format.\n" +
         "For example 'someone@example.com' ";
      return false;
   }
   // </Snippet1>
   // </Snippet2>
};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
