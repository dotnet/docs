#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Threading;

public ref class Form1: public System::Windows::Forms::Form
{
protected:
   ListBox^ textBox1;

   // <Snippet1>
   // Creates a class to throw the error.
public:
   ref class ErrorHandler: public System::Windows::Forms::Form
   {
      // Inserts the code to create a form with a button.

      // Programs the button to throw an exception when clicked.
   private:
      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         throw gcnew ArgumentException( "The parameter was invalid" );
      }

   public:
      static void Main()
      {
         // Creates an instance of the methods that will handle the exception.
         CustomExceptionHandler ^ eh = gcnew CustomExceptionHandler;
         
         // Adds the event handler to to the event.
         Application::ThreadException += gcnew ThreadExceptionEventHandler( eh, &Form1::CustomExceptionHandler::OnThreadException );
         
         // Runs the application.
         Application::Run( gcnew ErrorHandler );
      }
   };

   // Creates a class to handle the exception event.
internal:
   ref class CustomExceptionHandler
   {
      // Handles the exception event.
   public:
      void OnThreadException( Object^ /*sender*/, ThreadExceptionEventArgs^ t )
      {
         System::Windows::Forms::DialogResult result = ::DialogResult::Cancel;
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
         if ( result == ::DialogResult::Abort )
         {
            Application::Exit();
         }
      }

      // Creates the error message and displays it.
   private:
      System::Windows::Forms::DialogResult ShowThreadExceptionDialog( Exception^ e )
      {
         String^ errorMsg = "An error occurred please contact the adminstrator with the following information:\n\n";
         errorMsg = String::Concat( errorMsg, e->Message, "\n\nStack Trace:\n", e->StackTrace );
         return MessageBox::Show( errorMsg, "Application Error", MessageBoxButtons::AbortRetryIgnore, MessageBoxIcon::Stop );
      }
   };
   // </Snippet1>
};

int main()
{
   Form1::ErrorHandler::Main();
}
