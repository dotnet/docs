

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

namespace PropChanged
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::TextBox^ currencyTextBox;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;
         InitializeComponent();
      }

   protected:
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         this->currencyTextBox = gcnew System::Windows::Forms::TextBox;
         this->SuspendLayout();
         
         //
         // currencyTextBox
         //
         this->currencyTextBox->Location = System::Drawing::Point( 8, 8 );
         this->currencyTextBox->Name = "currencyTextBox";
         this->currencyTextBox->Size = System::Drawing::Size( 104, 20 );
         this->currencyTextBox->TabIndex = 0;
         this->currencyTextBox->Text = "";
         this->currencyTextBox->TextChanged += gcnew System::EventHandler( this, &Form1::currencyTextBox_TextChanged );
         
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 194, 103 );
         array<System::Windows::Forms::Control^>^temp0 = {this->currencyTextBox};
         this->Controls->AddRange( temp0 );
         this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      // <snippet1>
   private:
      void currencyTextBox_TextChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         try
         {
            // Convert the text to a Double and determine if it is a negative number.
            if ( Double::Parse( currencyTextBox->Text ) < 0 )
            {
               // If the number is negative, display it in Red.
               currencyTextBox->ForeColor = Color::Red;
            }
            else
            {
               // If the number is not negative, display it in Black.
               currencyTextBox->ForeColor = Color::Black;
            }
         }
         catch ( Exception^ ) 
         {
            // If there is an error, display the text using the system colors.
            currencyTextBox->ForeColor = SystemColors::ControlText;
         }
      }
      // </snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew PropChanged::Form1 );
}
