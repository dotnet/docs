

// System::Net::WebResponse::Headers
/* This program demonstrates the 'Headers' property of the 'WebResponse' class.
It creates a web request and queries for a response.It then prints out all the response
headers (name -value pairs) onto the console */
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
      // Create a 'WebRequest' object with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );

      // Send the 'WebRequest' and wait for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();

      // Display all the Headers present in the response received from the URl.
      Console::WriteLine( "\nThe following headers were received in the response" );

      // Display each header and its key , associated with the response object.
      for ( int i = 0; i < myWebResponse->Headers->Count; ++i )
         Console::WriteLine( "\nHeader Name: {0}, Header value : {1}", myWebResponse->Headers->Keys[ i ], myWebResponse->Headers[ i ] );

      // Release resources of response object.
      myWebResponse->Close();

      // </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Raised::Status is : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised.Message is : {0}", e->Message );
   }

}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease type the Url as command line parameter" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "WebResponse_Headers http://www.microsoft.com/net/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
