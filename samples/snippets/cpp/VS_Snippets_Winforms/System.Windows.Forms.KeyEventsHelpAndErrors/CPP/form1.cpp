

//<snippet1>
#using <System.dll>
#using <Microsoft.VisualBasic.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System;
using namespace Microsoft::VisualBasic;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      InitializeComponent();
      AddHandlers();
      InitializeFormHelp();
   }


public private:
   System::Windows::Forms::Label ^ Label1;
   System::Windows::Forms::Label ^ Label2;
   System::Windows::Forms::Label ^ Label3;
   System::Windows::Forms::TextBox^ withdrawal;
   System::Windows::Forms::TextBox^ deposit;
   System::Windows::Forms::ErrorProvider^ ErrorProvider1;
   System::Windows::Forms::Label ^ balance;
   System::Windows::Forms::HelpProvider^ HelpProvider1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->withdrawal = gcnew System::Windows::Forms::TextBox;
      this->deposit = gcnew System::Windows::Forms::TextBox;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->Label2 = gcnew System::Windows::Forms::Label;
      this->Label3 = gcnew System::Windows::Forms::Label;
      this->ErrorProvider1 = gcnew System::Windows::Forms::ErrorProvider;
      this->balance = gcnew System::Windows::Forms::Label;
      this->HelpProvider1 = gcnew System::Windows::Forms::HelpProvider;
      this->SuspendLayout();
      this->withdrawal->Location = System::Drawing::Point( 32, 200 );
      this->withdrawal->Name = "withdrawal";
      this->withdrawal->Size = System::Drawing::Size( 88, 20 );
      this->withdrawal->TabIndex = 0;
      this->withdrawal->Text = "";
      this->deposit->Location = System::Drawing::Point( 168, 200 );
      this->deposit->Name = "deposit";
      this->deposit->TabIndex = 1;
      this->deposit->Text = "";
      this->Label1->Location = System::Drawing::Point( 56, 88 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 96, 24 );
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Account Balance:";
      this->Label2->Location = System::Drawing::Point( 168, 168 );
      this->Label2->Name = "Label2";
      this->Label2->Size = System::Drawing::Size( 96, 24 );
      this->Label2->TabIndex = 4;
      this->Label2->Text = "Deposit:";
      this->Label3->Location = System::Drawing::Point( 32, 168 );
      this->Label3->Name = "Label3";
      this->Label3->Size = System::Drawing::Size( 96, 24 );
      this->Label3->TabIndex = 5;
      this->Label3->Text = "Withdrawal:";
      this->ErrorProvider1->ContainerControl = this;
      this->balance->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->balance->Location = System::Drawing::Point( 152, 88 );
      this->balance->Name = "balance";
      this->balance->TabIndex = 6;
      this->balance->Text = "345.65";
      this->balance->TextAlign = System::Drawing::ContentAlignment::MiddleLeft;
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->balance );
      this->Controls->Add( this->Label3 );
      this->Controls->Add( this->Label2 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->deposit );
      this->Controls->Add( this->withdrawal );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void AddHandlers()
   {
      
      // Add the event-handler delegates to handled the KeyDown
      // events.
      deposit->KeyDown += gcnew KeyEventHandler( this, &Form1::ProcessEntry );
      withdrawal->KeyDown += gcnew KeyEventHandler( this, &Form1::ProcessEntry );
      
      // Add the event-handler delegates to handled the KeyPress 
      // events.
      deposit->KeyPress += gcnew KeyPressEventHandler( this, &Form1::CheckForDigits );
      withdrawal->KeyPress += gcnew KeyPressEventHandler( this, &Form1::CheckForDigits );
   }


   //<snippet2>
   void InitializeFormHelp()
   {
      
      // Set the form's border to the FixedDialog style.
      this->FormBorderStyle = ::FormBorderStyle::FixedDialog;
      
      // Remove the Maximize and Minimize buttons from the form.
      this->MaximizeBox = false;
      this->MinimizeBox = false;
      
      // Add the Help button to the form.
      this->HelpButton = true;
      
      // Set the Help string for the deposit textBox.
      HelpProvider1->SetHelpString( deposit, "Enter an amount in the format xxx.xx"
      "and press Enter to deposit." );
      
      // Set the Help string for the withdrawal textBox.
      HelpProvider1->SetHelpString( withdrawal, "Enter an amount in the format xxx.xx"
      "and press Enter to withdraw." );
   }




   //</snippet2>
   void ProcessEntry( Object^ sender, KeyEventArgs^ e )
   {
      
      // Cast the sender back to a TextBox.
      Control^ textBoxSender = dynamic_cast<TextBox^>(sender);
      
      // Set the error description to an empty string ().
      ErrorProvider1->SetError( textBoxSender, "" );
      
      // Declare the variable to hold the new balance.
      double newBalance = 0;
      
      // Wrap the code in a Try/Catch block to catch 
      // errors that can occur when converting the string 
      // to a double.
      try
      {
         if ( e->KeyCode == Keys::Enter )
         {
            if ( textBoxSender->Name->Equals( "withdrawal" ) )
            {
               newBalance = Double::Parse( balance->Text ) - Double::Parse( withdrawal->Text );
               withdrawal->Text = "";
            }
            else
            if ( textBoxSender->Name->Equals( "deposit" ) )
            {
               newBalance = Double::Parse( balance->Text ) + Double::Parse( deposit->Text );
               deposit->Text = "";
            }
            
            // Check the value of new balance and set the
            // Forecolor property accordingly.
            if ( newBalance < 0 )
            {
               balance->ForeColor = Color::Red;
            }
            else
            {
               balance->ForeColor = Color::Black;
            }
            
            // Set the text of the balance text box
            // to the newBalance value.
            balance->Text = newBalance.ToString();
         }
      }
      catch ( FormatException^ ) 
      {
         
         // If a FormatException is thrown, set the
         // error string to the HelpString message for 
         // the control.
         ErrorProvider1->SetError( textBoxSender, HelpProvider1->GetHelpString( textBoxSender ) );
      }

   }

   void CheckForDigits( Object^ /*sender*/, KeyPressEventArgs^ e )
   {
      
      // If the character is not a digit, period, or backspace then
      // ignore it by setting the KeyPressEventArgs.Handled
      // property to true.
      if (  !(Char::IsDigit( e->KeyChar ) || e->KeyChar == '.' || e->KeyChar == (char)(Keys::Back)) )
      {
         e->Handled = true;
      }
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

//</snippet1>
