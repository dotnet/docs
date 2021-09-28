// System::Net::HttpWebResponse::StatusCode; System::Net::HttpWebResponse::StatusDescription

/* This program demonstrates the 'StatusCode' and 'StatusDescription' property of the 'HttpWebResponse' class.
It creates a web request and queries for a response. */

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
// <Snippet2>
void GetPage( String^ url )
{
   try
   {
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));
      // Sends the HttpWebRequest and waits for a response.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      if ( myHttpWebResponse->StatusCode == HttpStatusCode::OK )
      {
         Console::WriteLine( "\r\nResponse Status Code is OK and StatusDescription is: {0}",
            myHttpWebResponse->StatusDescription );
      }
      // Releases the resources of the response.
      myHttpWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException Raised. The following error occurred : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
}
// </Snippet2>
// </Snippet1>

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the url as command line parameter" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_StatusCode_StatusDescription http://dotnet.microsoft.com/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }
   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
