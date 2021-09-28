

// <Internal>
// This program contains examples for the following types and methods:
// System::Net::FileWebRequest (Snippet1); System::Net::FileWebRequest::Method (Snippet2);
// System::Net::FileWebRequest::Timeout (Snippet3);
// System::Net::FileWebRequest::ContentLength (Snippet4).
// System::Net::FileWebRequest::GetRequestStream (Snippet5);
// </Internal>
// <Snippet1>
// This program creates or open a text file in which it stores a string.
// Both file and string are passed by the user.
// Note. In order for this program to work, the folder containing the test file
// must be shared with its permissions set to allow write access.
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Net;
ref class TestGetRequestStream
{
private:
   static FileWebRequest^ myFileWebRequest;
   static void showUsage()
   {
      Console::WriteLine( "\nPlease enter file name and timeout :" );
      Console::WriteLine( "Usage: cs_getrequeststream <systemname>/<sharedfoldername>/<filename> timeout" );
      Console::WriteLine( "Example: cs_getrequeststream ndpue/temp/hello.txt 1000" );
      Console::WriteLine( "Small timeout values (for instance 3 or less) cause a timeout exception." );
   }

   static void makeFileRequest( String^ fileName, int timeout )
   {
      try
      {
         
         // <Snippet2>
         // <Snippet3>
         // Create a Uri object.
         Uri^ myUrl = gcnew Uri( String::Format( "file://{0}", fileName ) );
         
         // Create a FileWebRequest object.
         myFileWebRequest = dynamic_cast<FileWebRequest^>(WebRequest::CreateDefault( myUrl ));
         
         // Set the timeout to the value selected by the user.
         myFileWebRequest->Timeout = timeout;
         
         // </Snippet3>
         // Set the Method property to POST
         myFileWebRequest->Method = "POST";
         
         // </Snippet2>
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "WebException: {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "UriFormatWebException: {0}", e->Message );
      }

   }

   static void writeToFile()
   {
      try
      {
         
         // <Snippet5>
         // Enter the string to write into the file.
         Console::WriteLine( "Enter the string you want to write:" );
         String^ userInput = Console::ReadLine();
         
         // Convert the string to Byte array.
         ASCIIEncoding^ encoder = gcnew ASCIIEncoding;
         array<Byte>^byteArray = encoder->GetBytes( userInput );
         
         // <Snippet4>
         // Set the ContentLength property.
         myFileWebRequest->ContentLength = byteArray->Length;
         String^ contentLength = myFileWebRequest->ContentLength.ToString();
         Console::WriteLine( "\nThe content length is {0}.", contentLength );
         
         // </Snippet4>
         // Get the file stream handler to write into the file.
         Stream^ readStream = myFileWebRequest->GetRequestStream();
         
         // Write to the file stream.
         // Note. In order for this to work the file must be accessible
         // on the network. This can be accomplished by setting the property
         // sharing of the folder containg the file. The permissions
         // can be set so everyone can modify the file.
         // FileWebRequest::Credentials property cannot be used for this purpose.
         readStream->Write( byteArray, 0, userInput->Length );
         Console::WriteLine( "\nThe String you entered was successfully written into the file." );
         
         // </Snippet5>
         readStream->Close();
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "The WebException: {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "The UriFormatWebException: {0}", e->Message );
      }

   }


public:
   static void Main()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      if ( args->Length < 3 )
            showUsage();
      else
      {
         makeFileRequest( args[ 1 ], Int32::Parse( args[ 2 ] ) );
         writeToFile();
      }
   }

};

int main()
{
   TestGetRequestStream::Main();
}

// </Snippet1>
