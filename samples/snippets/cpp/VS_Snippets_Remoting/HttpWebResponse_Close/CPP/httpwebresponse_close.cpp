// System::Net::HttpWebResponse::Close
/* This program demonstrates the 'Close' method of the 'HttpWebResponse' class.
It creates a web request and queries for a response.The response Object* can be processed as desired.
The program then closes the response Object* and releases resources associated with it.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

void GetPage( String^ url )
{
   try
   {
// <Snippet1>
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( url ) );
      // Sends the HttpWebRequest and waits for a response.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      Console::WriteLine( "\nResponse Received::Trying to Close the response stream.." );
      // Releases the resources of the response.
      myHttpWebResponse->Close();
      Console::WriteLine( "\nResponse Stream successfully closed" );
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Raised. The following error occurred : {0}", e->Status );
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
      Console::WriteLine( "\nPlease enter the url as command line parameter:" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_Close http://dotnet.microsoft.com/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }
   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
