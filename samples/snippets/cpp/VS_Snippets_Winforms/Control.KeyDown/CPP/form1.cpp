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
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();
      
      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 64, 48 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 200, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "textBox1";
      this->textBox1->KeyDown += gcnew System::Windows::Forms::KeyEventHandler( this, &Form1::textBox1_KeyDown );
      this->textBox1->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler( this, &Form1::textBox1_KeyPress );
      
      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 376, 342 );
      array<System::Windows::Forms::Control^>^temp0 = {this->textBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<Snippet1>
   // Boolean flag used to determine when a character other than a number is entered.
private:
   bool nonNumberEntered;

   // Handle the KeyDown event to determine the type of character entered into the control.
   void textBox1_KeyDown( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      // Initialize the flag to false.
      nonNumberEntered = false;

      // Determine whether the keystroke is a number from the top of the keyboard.
      if ( e->KeyCode < Keys::D0 || e->KeyCode > Keys::D9 )
      {
         // Determine whether the keystroke is a number from the keypad.
         if ( e->KeyCode < Keys::NumPad0 || e->KeyCode > Keys::NumPad9 )
         {
            // Determine whether the keystroke is a backspace.
            if ( e->KeyCode != Keys::Back )
            {
               // A non-numerical keystroke was pressed.
               // Set the flag to true and evaluate in KeyPress event.
               nonNumberEntered = true;
            }
         }
      }
      //If shift key was pressed, it's not a number.
      if (Control::ModifierKeys == Keys::Shift) {
         nonNumberEntered = true;
      }
   }

   // This event occurs after the KeyDown event and can be used to prevent
   // characters from entering the control.
   void textBox1_KeyPress( Object^ /*sender*/, System::Windows::Forms::KeyPressEventArgs^ e )
   {
      // Check for the flag being set in the KeyDown event.
      if ( nonNumberEntered == true )
      {         // Stop the character from being entered into the control since it is non-numerical.
         e->Handled = true;
      }
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
