

//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;
using namespace System::Text;
using namespace System::IO;

// A simple form that represents a window in our application
public ref class AppForm2: public System::Windows::Forms::Form
{
public:
   AppForm2()
   {
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "AppForm2";
   }

};


// A simple form that represents a window in our application
public ref class AppForm1: public System::Windows::Forms::Form
{
public:
   AppForm1()
   {
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "AppForm1";
   }

};


//<Snippet2>
// The class that handles the creation of the application windows
ref class MyApplicationContext: public ApplicationContext
{
private:
   int formCount;
   AppForm1^ form1;
   AppForm2^ form2;
   System::Drawing::Rectangle form1Position;
   System::Drawing::Rectangle form2Position;
   FileStream^ userData;

public:

   //<Snippet5>
   MyApplicationContext()
   {
      formCount = 0;
      
      // Handle the ApplicationExit event to know when the application is exiting.
      Application::ApplicationExit += gcnew EventHandler( this, &MyApplicationContext::OnApplicationExit );
      try
      {
         
         // Create a file that the application will store user specific data in.
         userData = gcnew FileStream( String::Concat( Application::UserAppDataPath, "\\appdata.txt" ),FileMode::OpenOrCreate );
      }
      catch ( IOException^ e ) 
      {
         
         // Inform the user that an error occurred.
         MessageBox::Show( "An error occurred while attempting to show the application. The error is: {0}", dynamic_cast<String^>(e) );
         
         // Exit the current thread instead of showing the windows.
         ExitThread();
      }

      
      // Create both application forms and handle the Closed event
      // to know when both forms are closed.
      form1 = gcnew AppForm1;
      form1->Closed += gcnew EventHandler( this, &MyApplicationContext::OnFormClosed );
      form1->Closing += gcnew CancelEventHandler( this, &MyApplicationContext::OnFormClosing );
      formCount++;
      form2 = gcnew AppForm2;
      form2->Closed += gcnew EventHandler( this, &MyApplicationContext::OnFormClosed );
      form2->Closing += gcnew CancelEventHandler( this, &MyApplicationContext::OnFormClosing );
      formCount++;
      
      // Get the form positions based upon the user specific data.
      if ( ReadFormDataFromFile() )
      {
         
         // If the data was read from the file, set the form
         // positions manually.
         form1->StartPosition = FormStartPosition::Manual;
         form2->StartPosition = FormStartPosition::Manual;
         form1->Bounds = form1Position;
         form2->Bounds = form2Position;
      }

      
      // Show both forms.
      form1->Show();
      form2->Show();
   }

   void OnApplicationExit( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // When the application is exiting, write the application data to the
      // user file and close it.
      WriteFormDataToFile();
      try
      {
         
         // Ignore any errors that might occur while closing the file handle.
         userData->Close();
      }
      catch ( Exception^ ) 
      {
      }

   }


private:

   //</Snippet5>
   void OnFormClosing( Object^ sender, CancelEventArgs^ /*e*/ )
   {
      
      // When a form is closing, remember the form position so it
      // can be saved in the user data file.
      if ( dynamic_cast<AppForm1^>(sender) != nullptr )
            form1Position = (dynamic_cast<Form^>(sender))->Bounds;
      else
      if ( dynamic_cast<AppForm1^>(sender) != nullptr )
            form2Position = (dynamic_cast<Form^>(sender))->Bounds;
   }


   //<Snippet3>
   void OnFormClosed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // When a form is closed, decrement the count of open forms.
      // When the count gets to 0, exit the app by calling
      // ExitThread().
      formCount--;
      if ( formCount == 0 )
      {
         ExitThread();
      }
   }


   //</Snippet3>
   bool WriteFormDataToFile()
   {
      
      // Write the form positions to the file.
      UTF8Encoding^ encoding = gcnew UTF8Encoding;
      RectangleConverter^ rectConv = gcnew RectangleConverter;
      String^ form1pos = rectConv->ConvertToString( form1Position );
      String^ form2pos = rectConv->ConvertToString( form2Position );
      array<Byte>^dataToWrite = encoding->GetBytes( String::Concat( "~", form1pos, "~", form2pos ) );
      try
      {
         
         // Set the write position to the start of the file and write
         userData->Seek( 0, SeekOrigin::Begin );
         userData->Write( dataToWrite, 0, dataToWrite->Length );
         userData->Flush();
         userData->SetLength( dataToWrite->Length );
         return true;
      }
      catch ( Exception^ ) 
      {
         
         // An error occurred while attempting to write, return false.
         return false;
      }

   }

   bool ReadFormDataFromFile()
   {
      
      // Read the form positions from the file.
      UTF8Encoding^ encoding = gcnew UTF8Encoding;
      String^ data;
      if ( userData->Length != 0 )
      {
         array<Byte>^dataToRead = gcnew array<Byte>(userData->Length);
         try
         {
            
            // Set the read position to the start of the file and read.
            userData->Seek( 0, SeekOrigin::Begin );
            userData->Read( dataToRead, 0, dataToRead->Length );
         }
         catch ( IOException^ e ) 
         {
            String^ errorInfo = dynamic_cast<String^>(e);
            
            // An error occurred while attempt to read, return false.
            return false;
         }

         
         // Parse out the data to get the window rectangles
         data = encoding->GetString( dataToRead );
         try
         {
            
            // Convert the String* data to rectangles
            RectangleConverter^ rectConv = gcnew RectangleConverter;
            String^ form1pos = data->Substring( 1, data->IndexOf( "~", 1 ) - 1 );
            form1Position =  *safe_cast<Rectangle^>(rectConv->ConvertFromString( form1pos ));
            String^ form2pos = data->Substring( data->IndexOf( "~", 1 ) + 1 );
            form2Position =  *safe_cast<Rectangle^>(rectConv->ConvertFromString( form2pos ));
            return true;
         }
         catch ( Exception^ ) 
         {
            
            // Error occurred while attempting to convert the rectangle data.
            // Return false to use default values.
            return false;
         }

      }
      else
      {
         
         // No data in the file, return false to use default values.
         return false;
      }
   }

};


//</Snippet2>
//<Snippet4>

[STAThread]
int main()
{
   
   // Create the MyApplicationContext, that derives from ApplicationContext,
   // that manages when the application should exit.
   MyApplicationContext^ context = gcnew MyApplicationContext;
   
   // Run the application with the specific context. It will exit when
   // all forms are closed.
   Application::Run( context );
}

//</Snippet4>
//</Snippet1>
