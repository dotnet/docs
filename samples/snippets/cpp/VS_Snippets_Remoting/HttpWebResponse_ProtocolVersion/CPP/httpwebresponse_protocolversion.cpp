// System::Net::HttpWebResponse::ProtocolVersion
/* This program demonstrates the 'ProtocolVersion' property of the 'HttpWebResponse' class.
It creates a web request and queries for a response.The server should respond using the same version */

#using <System.dll>

using namespace System;
using namespace System::Net;

void GetPage( String^ url )
{
   try
   {
// <Snippet1>
      Uri^ ourUri = gcnew Uri( url );
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( ourUri ) );
      myHttpWebRequest->ProtocolVersion = HttpVersion::Version10;
      // Sends the HttpWebRequest and waits for the response.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      // Ensures that only Http/1.0 responses are accepted.
      if ( myHttpWebResponse->ProtocolVersion != HttpVersion::Version10 )
      {
         Console::WriteLine( "\nThe server responded with a version other than Http/1.0" );
      }
      else if ( myHttpWebResponse->StatusCode == HttpStatusCode::OK )
      {
         Console::WriteLine( "\nRequest sent using version Http/1.0. Successfully received response with version HTTP/1.0 " );
      }
      // Releases the resources of the response.
      myHttpWebResponse->Close();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Raised. The following error occured : {0}", e->Status );
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
      Console::WriteLine( "\nPlease enter the url as command line parameter" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_ProtocolVersion http://www.microsoft.com/net/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }
   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
