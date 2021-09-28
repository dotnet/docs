// System::Net::FileWebResponse::Headers

/* This program demonstrates the 'Headers' property of the 'FileWebResponse' class.
It creates a web request and queries for a response.It then prints [Out] all* the response
headers (name -value pairs) onto the console. */

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
void GetPage( String^ url )
{
   try
   {
      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      // Create a 'FileWebrequest' Object^ with the specified Uri .
      FileWebRequest^ myFileWebRequest = (FileWebRequest^)(WebRequest::Create( fileUrl ));
      // Send the 'FileWebRequest' and wait for response.
      FileWebResponse^ myFileWebResponse = (FileWebResponse^)(myFileWebRequest->GetResponse());
      // Display all Headers present in the response received from the Uri.
      Console::WriteLine( "\r\nThe following headers were received in the response:" );
      // Display each header and the key of the response Object^.
      for ( int i = 0; i < myFileWebResponse->Headers->Count; ++i )
         Console::WriteLine( "\nHeader Name: {0}, Header value : {1}",
            myFileWebResponse->Headers->Keys[ i ], myFileWebResponse->Headers[ (HttpRequestHeader)i ] );
      myFileWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException thrown. The Reason for failure is: {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised: {0}", e->Message );
   }

}
// </Snippet1>

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease type the file name as command line parameter as:" );
      Console::WriteLine( "Usage:FileWebResponse_Headers <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_Headers microsoft/shared/hello.txt" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
