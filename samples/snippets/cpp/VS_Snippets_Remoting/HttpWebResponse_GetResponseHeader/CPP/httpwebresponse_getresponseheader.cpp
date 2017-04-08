// System::Net::HttpWebResponse::GetResponseHeader
/* This program demonstrates the 'GetResponseHeader' method of the 'HttpWebResponse' class
It creates a web request and queries for a response.If the site requires authentication it
will respond with a challenge String* which is extracted using 'GetResponse()' method.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
void GetPage( String^ url )
{
   try
   {
      Uri^ ourUri = gcnew Uri( url );
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( ourUri ) );
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      Console::WriteLine( "\nThe server did not issue any challenge.  Please try again with a protected resource URL." );
      // Releases the resources of the response.
      myHttpWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      HttpWebResponse^ response = (HttpWebResponse^)( e->Response );
      if ( response != nullptr )
      {
         if ( response->StatusCode == HttpStatusCode::Unauthorized )
         {
            String^ challenge = nullptr;
            challenge = response->GetResponseHeader( "WWW-Authenticate" );
            if ( challenge != nullptr )
                        Console::WriteLine( "\nThe following challenge was raised by the server: {0}", challenge );
         }
         else
         {
            Console::WriteLine( "\nThe following WebException was raised : {0}", e->Message );
         }
      }
      else
      {
         Console::WriteLine( "\nResponse Received from server was 0" );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
}
// </Snippet1>

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter a protected resource url as command line parameter:" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_GetResponseHeader http://www.microsoft.com/net/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
