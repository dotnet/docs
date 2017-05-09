

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

//<snippet2>
using namespace System::Windows::Forms;

//<snippet1>
// This button is a simple extension of the button class that overrides
// the ProcessMnemonic method.  If the mnemonic is correctly entered,  
// the message box will appear and the click event will be raised.  
// This method makes sure the control is selectable and the 
// mnemonic is correct before displaying the message box
// and triggering the click event.
public ref class MyMnemonicButton: public Button
{
protected:
   bool ProcessMnemonic( char inputChar )
   {
      if ( CanSelect && IsMnemonic( inputChar, this->Text ) )
      {
         MessageBox::Show( "You've raised the click event "
         "using the mnemonic." );
         this->PerformClick();
         return true;
      }

      return false;
   }

};


//</snippet1>
// Declare the controls contained on the form.
public ref class Form1: public System::Windows::Forms::Form
{
private:
   MyMnemonicButton^ button1;

public private:
   System::Windows::Forms::ListBox^ ListBox1;

public:
   Form1()
      : Form()
   {
      
      // Set KeyPreview object to true to allow the form to process 
      // the key before the control with focus processes it.
      this->KeyPreview = true;
      
      // Add a MyMnemonicButton.  
      button1 = gcnew MyMnemonicButton;
      button1->Text = "&Click";
      button1->Location = System::Drawing::Point( 100, 120 );
      this->Controls->Add( button1 );
      
      // Initialize a ListBox control and the form itself.
      this->ListBox1 = gcnew System::Windows::Forms::ListBox;
      this->SuspendLayout();
      this->ListBox1->Location = System::Drawing::Point( 8, 8 );
      this->ListBox1->Name = "ListBox1";
      this->ListBox1->Size = System::Drawing::Size( 120, 95 );
      this->ListBox1->TabIndex = 0;
      this->ListBox1->Text = "Press a key";
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->ListBox1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
      
      // Associate the event-handling method with the
      // KeyDown event.
      this->KeyDown += gcnew KeyEventHandler( this, &Form1::Form1_KeyDown );
   }


private:

   // The form will handle all key events before the control with  
   // focus handles them.  Show the keys pressed by adding the
   // KeyCode object to ListBox1. Ensure the processing is passed
   // to the control with focus by setting the KeyEventArg.Handled
   // property to false.
   void Form1_KeyDown( Object^ /*sender*/, KeyEventArgs^ e )
   {
      ListBox1->Items->Add( e->KeyCode );
      e->Handled = false;
   }

};


[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}

//</snippet2>
