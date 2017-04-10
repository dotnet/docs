

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Threading;
using namespace System::Windows::Forms;

// Creates a class to handle the exception event.
private ref class CustomExceptionHandler
{
public:

   //Handles the exception event
   void OnThreadException( Object^ /*sender*/, ThreadExceptionEventArgs^ t )
   {
      DialogResult result = DialogResult::Cancel;
      try
      {
         result = this->ShowThreadExceptionDialog( t->Exception );
      }
      catch ( Exception^ ) 
      {
         try
         {
            MessageBox::Show( "Fatal Error", "Fatal Error", MessageBoxButtons::AbortRetryIgnore, MessageBoxIcon::Stop );
         }
         finally
         {
            Application::Exit();
         }

      }

      
      // Exits the program when the user clicks Abort.
      if ( result == DialogResult::Abort )
            Application::Exit();
   }


private:

   // Creates the error message and display it.
   DialogResult ShowThreadExceptionDialog( Exception^ e )
   {
      String^ errorMsg = "An error occurred please contact the adminstrator with the following information:\n\n";
      errorMsg = String::Concat( errorMsg, e->Message, "\n\nStack Trace:\n", e->StackTrace );
      return MessageBox::Show( errorMsg, "Application Error", MessageBoxButtons::AbortRetryIgnore, MessageBoxIcon::Stop );
   }

};


// Creates a class to throw the error.
public ref class ErrorHandler: public System::Windows::Forms::Form
{
private:

   // Inserts code to create a form with a button.
   // Programs the button to throw the exception when clicked.
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      throw gcnew ArgumentException( "The parameter was invalid" );
   }

};

int main()
{
   
   // Creates an instance of the methods that will handle the exception.
   CustomExceptionHandler^ eh = gcnew CustomExceptionHandler;
   
   // Adds the event handler to to the event.
   Application::ThreadException += gcnew ThreadExceptionEventHandler( eh, &CustomExceptionHandler::OnThreadException );
   
   // Runs the application.
   Application::Run( gcnew ErrorHandler );
}

