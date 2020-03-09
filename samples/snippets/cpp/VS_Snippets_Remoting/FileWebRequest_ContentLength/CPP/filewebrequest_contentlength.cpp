// System::Net::FileWebRequest::ContentLength;System::Net::FileWebRequest::RequestUri;

/*
This program demonstrates 'ContentLength'and 'RequestUri' property of 'FileWebRequest' class.
The path of a file where user would like to write something is obtained from command line argument.
Then a 'WebRequest' Object* is created. The 'ContentLength' property of 'FileWebRequest' is used to
set the length of the file content that was written.
*/

#using <System.dll>

using namespace System::Net;
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the file name as command line parameter where you want to write:" );
      Console::WriteLine( "Usage:FileWebRequest_ContentLen <systemname>/<sharedfoldername>/<filename>\nExample:FileWebRequest_ContentLen shafeeque/shaf/hello.txt" );
   }
   else
   {
      try
      {
         // Create an 'Uri' Object*.
         Uri^ myUrl = gcnew Uri( String::Concat( "file://", args[ 1 ] ) );
         FileWebRequest^ myFileWebRequest = nullptr;
         
// <Snippet1>
         myFileWebRequest = (FileWebRequest^)( WebRequest::Create( myUrl ) );

         Console::WriteLine( "Enter the string you want to write into the file:" );
         String^ userInput = Console::ReadLine();
         ASCIIEncoding^ encoder = gcnew ASCIIEncoding;
         array<Byte>^ byteArray = encoder->GetBytes( userInput );
         
         // Set the 'Method' property of 'FileWebRequest' Object* to 'POST' method.
         myFileWebRequest->Method = "POST";
         
         // The 'ContentLength' property is used to set the content length of the file.
         myFileWebRequest->ContentLength = byteArray->Length;
// </Snippet1>

// <Snippet2>
         // Compare the file name and 'RequestUri' is same or not.
         if ( myFileWebRequest->RequestUri->Equals( myUrl ) )
         {
            // 'GetRequestStream' method returns the stream handler for writing into the file.
            Stream^ readStream = myFileWebRequest->GetRequestStream();
            // Write to the stream
            readStream->Write( byteArray, 0, userInput->Length );
            readStream->Close();
         }

         Console::WriteLine( "\nThe String you entered was successfully written into the file." );
         Console::WriteLine( "The content length sent to the server is {0}.", myFileWebRequest->ContentLength );
// </Snippet2>
      }
      catch ( ArgumentException^ e ) 
      {
         Console::WriteLine( "The ArgumentException is : {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "The UriFormatException is : {0}", e->Message );
      }
   }
}
