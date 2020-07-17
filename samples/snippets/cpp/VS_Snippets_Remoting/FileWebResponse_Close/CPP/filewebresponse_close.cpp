// System::Net::FileWebResponse::Close
/*This program demontrates the  'Close' method of 'FileWebResponse' Class.
It takes an Uri from console and creates a 'FileWebRequest' Object* for the Uri::It then gets back
the response Object* from the Uri. The response Object* can be processed as desired.The program then
closes the response Object* and releases resources associated with it.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;

// <Snippet1>
void GetPage( String^ url )
{
   try
   {
      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      // Create a FileWebrequest with the specified Uri.
      FileWebRequest^ myFileWebRequest = dynamic_cast<FileWebRequest^>(WebRequest::Create( fileUrl ));
      // Send the 'fileWebRequest' and wait for response.
      FileWebResponse^ myFileWebResponse = dynamic_cast<FileWebResponse^>(myFileWebRequest->GetResponse());
      // Process the response here.
      Console::WriteLine( "\nResponse Received::Trying to Close the response stream.." );
      // Release resources of response Object*.
      myFileWebResponse->Close();
      Console::WriteLine( "\nResponse Stream successfully closed." );
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
// </Snippet1>

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the file name as command line parameter:" );
      Console::WriteLine( "Usage:FileWebResponse_Close <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_Close microsoft/shared/hello.txt" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
   return 0;
}
