

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
   public ref class MyTextBox: public TextBox
   {
      // <snippet1>
   protected:
      virtual void OnTextChanged( System::EventArgs^ e ) override
      {
         try
         {
            // Convert the text to a Double and determine
            // if it is a negative number.
            if ( Double::Parse( this->Text ) < 0 )
            {
               // If the number is negative, display it in Red.
               this->ForeColor = Color::Red;
            }
            else
            {
               // If the number is not negative, display it in Black.
               this->ForeColor = Color::Black;
            }
         }
         catch ( Exception^ ) 
         {
            // If there is an error, display the
            // text using the system colors.
            this->ForeColor = SystemColors::ControlText;
         }

         TextBox::OnTextChanged( e );
      }
      // </snippet1>
   };

   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      MyTextBox^ currencyTextBox;
      System::Windows::Forms::Button^ button1;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
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
         this->currencyTextBox = gcnew PropChanged::MyTextBox;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // currencyTextBox
         //
         this->currencyTextBox->Location = System::Drawing::Point( 8, 8 );
         this->currencyTextBox->Name = "currencyTextBox";
         this->currencyTextBox->Size = System::Drawing::Size( 104, 20 );
         this->currencyTextBox->TabIndex = 0;
         this->currencyTextBox->Text = "";

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 64, 48 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 1;
         this->button1->Text = "button1";

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 194, 103 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->currencyTextBox};
         this->Controls->AddRange( temp0 );
         this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew PropChanged::Form1 );
}
