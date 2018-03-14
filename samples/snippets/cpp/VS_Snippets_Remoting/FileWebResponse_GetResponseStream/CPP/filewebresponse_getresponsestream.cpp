// System::Net::FileWebResponse::GetResponseStream.

/* This program demonstrates the 'GetResponseStream' method of the 'FileWebResponse' class.
It creates a 'FileWebRequest' Object* and queries for a response.
The response stream obtained is piped to a higher level stream reader. The reader reads
256 characters at a time , writes them into a String* and then displays the String* onto the console*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;

void GetPage( String^ url )
{
   try
   {
// <Snippet1>
      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      // Create a 'FileWebrequest' Object* with the specified Uri.
      FileWebRequest^ myFileWebRequest = (FileWebRequest^)( WebRequest::Create( fileUrl ) );
      // Send the 'FileWebRequest' Object* and wait for response.
      FileWebResponse^ myFileWebResponse = (FileWebResponse^)( myFileWebRequest->GetResponse() );
      
      // Get the stream Object* associated with the response Object*.
      Stream^ receiveStream = myFileWebResponse->GetResponseStream();

      Encoding^ encode = System::Text::Encoding::GetEncoding( "utf-8" );
      // Pipe the stream to a higher level stream reader with the required encoding format.
      StreamReader^ readStream = gcnew StreamReader( receiveStream,encode );
      Console::WriteLine( "\r\nResponse stream received" );

      array<Char>^ read = gcnew array<Char>(256);
      // Read 256 characters at a time.
      int count = readStream->Read( read, 0, 256 );
      Console::WriteLine( "File Data...\r\n" );
      while ( count > 0 )
      {
         // Dump the 256 characters on a String* and display the String* onto the console.
         String^ str = gcnew String( read,0,count );
         Console::Write( str );
         count = readStream->Read( read, 0, 256 );
      }
      Console::WriteLine( "" );
      // Release resources of stream Object*.
      readStream->Close();
      // Release resources of response Object*.
      myFileWebResponse->Close();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException thrown.The Reason for failure is : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
}

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the file name as command line parameter:" );
      Console::WriteLine( "Usage:FileWebResponse_GetResponseStream <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_GetResponseStream microsoft/shared/hello.txt" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
