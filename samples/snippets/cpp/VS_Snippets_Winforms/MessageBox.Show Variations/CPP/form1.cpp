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

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::TextBox^ serverName;
   System::Windows::Forms::Button^ button1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;
      
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
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
      this->serverName = gcnew System::Windows::Forms::TextBox;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // serverName
      //
      this->serverName->Location = System::Drawing::Point( 32, 40 );
      this->serverName->Name = "serverName";
      this->serverName->TabIndex = 0;
      this->serverName->Text = "textBox1";

      // 
      // button1
      //
      this->button1->Location = System::Drawing::Point( 40, 96 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^formControls = {this->button1,this->serverName};
      this->Controls->AddRange( formControls );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      validateUserEntry();
      validateUserEntry2();
      validateUserEntry3();
      validateUserEntry4();
      validateUserEntry5();
   }

   //<snippet1>
private:
   void validateUserEntry()
   {
      // Checks the value of the text.
      if ( serverName->Text->Length == 0 )
      {
         // Initializes the variables to pass to the MessageBox::Show method.
         String^ message = "You did not enter a server name. Cancel this operation?";
         String^ caption = "No Server Name Specified";
         MessageBoxButtons buttons = MessageBoxButtons::YesNo;
         System::Windows::Forms::DialogResult result;

         // Displays the MessageBox.
         result = MessageBox::Show( this, message, caption, buttons );
         if ( result == ::DialogResult::Yes )
         {
            // Closes the parent form.
            this->Close();
         }
      }
   }
   //</snippet1>

   //<snippet2>
private:
   void validateUserEntry2()
   {
      // Checks the value of the text.
      if ( serverName->Text->Length == 0 )
      {
         // Initializes the variables to pass to the MessageBox::Show method.
         String^ message = "You did not enter a server name. Cancel this operation?";
         String^ caption = "No Server Name Specified";
         MessageBoxButtons buttons = MessageBoxButtons::YesNo;
         System::Windows::Forms::DialogResult result;
         
         // Displays the MessageBox.
         result = MessageBox::Show( this, message, caption, buttons, MessageBoxIcon::Question, MessageBoxDefaultButton::Button1, MessageBoxOptions::RightAlign );
         if ( result == ::DialogResult::Yes )
         {
            // Closes the parent form.
            this->Close();
         }
      }
   }
   //</snippet2>

   //<snippet3>
private:
   void validateUserEntry3()
   {
      // Checks the value of the text.
      if ( serverName->Text->Length == 0 )
      {
         // Initializes the variables to pass to the MessageBox::Show method.
         String^ message = "You did not enter a server name. Cancel this operation?";
         String^ caption = "No Server Name Specified";
         MessageBoxButtons buttons = MessageBoxButtons::YesNo;
         System::Windows::Forms::DialogResult result;

         // Displays the MessageBox.
         result = MessageBox::Show( this, message, caption, buttons, MessageBoxIcon::Question, MessageBoxDefaultButton::Button1 );
         if ( result == ::DialogResult::Yes )
         {
            // Closes the parent form.
            this->Close();
         }
      }
   }
   //</snippet3>

   //<snippet4>
private:
   void validateUserEntry4()
   {
      // Checks the value of the text.
      if ( serverName->Text->Length == 0 )
      {
         // Initializes the variables to pass to the MessageBox::Show method.
         String^ message = "You did not enter a server name. Cancel this operation?";
         String^ caption = "No Server Name Specified";
         MessageBoxButtons buttons = MessageBoxButtons::YesNo;
         System::Windows::Forms::DialogResult result;

         // Displays the MessageBox.
         result = MessageBox::Show( this, message, caption, buttons, MessageBoxIcon::Question );
         if ( result == ::DialogResult::Yes )
         {
            // Closes the parent form.
            this->Close();
         }
      }
   }
   //</snippet4>

   //<snippet5>
private:
   void validateUserEntry5()
   {
      // Checks the value of the text.
      if ( serverName->Text->Length == 0 )
      {
         // Initializes the variables to pass to the MessageBox::Show method.
         String^ message = "You did not enter a server name. Cancel this operation?";
         String^ caption = "No Server Name Specified";
         MessageBoxButtons buttons = MessageBoxButtons::YesNo;
         System::Windows::Forms::DialogResult result;

         // Displays the MessageBox.
         result = MessageBox::Show( this, message, caption, buttons );
         if ( result == ::DialogResult::Yes )
         {
            // Closes the parent form.
            this->Close();
         }
      }
   }
   //</snippet5>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
