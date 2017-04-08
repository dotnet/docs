

// <Internal>
// This program contains examples for the following types and methods:
// System::Net::FileWebRequest::GetResponse;
// </Internal>
// <Snippet1>
//
// This program shows how to use the FileWebRequest::GetResponse method 
// to read and display the content of a file passed by the user.
// Note. In order for this program to work, the folder containing the test file
// must be shared with its permissions set to allow read access. 
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
ref class TestGetResponse
{
private:
   static FileWebResponse^ myFileWebResponse;
   static void showUsage()
   {
      Console::WriteLine( "\nPlease enter file name:" );
      Console::WriteLine( "Usage: cs_getresponse <systemname>/<sharedfoldername>/<filename>" );
      Console::WriteLine( "Example: cs_getresponse ndpue/temp/hello.txt" );
   }

   static bool makeFileRequest( String^ fileName )
   {
      bool requestOk = false;
      try
      {
         Uri^ myUrl = gcnew Uri( String::Format( "file://{0}", fileName ) );
         
         // Create a Filewebrequest object using the passed Uri. 
         FileWebRequest^ myFileWebRequest = dynamic_cast<FileWebRequest^>(WebRequest::Create( myUrl ));
         
         // Get the FileWebResponse object.
         myFileWebResponse = dynamic_cast<FileWebResponse^>(myFileWebRequest->GetResponse());
         requestOk = true;
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "WebException: {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "UriFormatWebException: {0}", e->Message );
      }

      return requestOk;
   }

   static void readFile()
   {
      try
      {
         
         // Create the file stream. 
         Stream^ receiveStream = myFileWebResponse->GetResponseStream();
         
         // Create a reader object to read the file content.
         StreamReader^ readStream = gcnew StreamReader( receiveStream );
         
         // Create a local buffer for a temporary storage of the 
         // read data.
         array<Char>^readBuffer = gcnew array<Char>(256);
         
         // Read the first up to 256 bytes.
         int count = readStream->Read( readBuffer, 0, 256 );
         Console::WriteLine( "The file content is:" );
         Console::WriteLine( "" );
         
         // Loop to read the remaining bytes in 256 blocks
         // and display the data on the console.
         while ( count > 0 )
         {
            String^ str = gcnew String( readBuffer,0,count );
            Console::WriteLine(  "{0}\n", str );
            count = readStream->Read( readBuffer, 0, 256 );
         }
         readStream->Close();
         
         // Release the response object resources.
         myFileWebResponse->Close();
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "The WebException: {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "The UriFormatException: {0}", e->Message );
      }

   }


public:
   static void Main()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      if ( args->Length < 2 )
            showUsage();
      else
      {
         if ( makeFileRequest( args[ 1 ] ) )
                  readFile();
      }
   }

};

int main()
{
   TestGetResponse::Main();
}

// </Snippet1>
