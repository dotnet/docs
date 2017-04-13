// System::Net::HttpWebResponse::ResponseUri
/*This program demonstrates the 'ResponseUri' property of the 'HttpWebResponse' class
It creates a web request and queries for a response.It checks if the original Uri
was redirected by the server. */

#using <System.dll>

using namespace System;
using namespace System::Net;

void GetPage( String^ url )
{
   try
   {
// <Snippet1>
      Uri^ myUri = gcnew Uri( url );
      // Create a 'HttpWebRequest' object for the specified url.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( myUri ) );
      // Send the request and wait for response.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      if ( myHttpWebResponse->StatusCode == HttpStatusCode::OK )
      {
         Console::WriteLine( "\nRequest succeeded and the requested information is in the response , Description : {0}",
            myHttpWebResponse->StatusDescription );
      }
      if ( myUri->Equals( myHttpWebResponse->ResponseUri ) )
      {
         Console::WriteLine( "\nThe Request Uri was not redirected by the server" );
      }
      else
      {
         Console::WriteLine( "\nThe Request Uri was redirected to : {0}", myHttpWebResponse->ResponseUri );
      }
      // Release resources of response Object*.
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
      Console::WriteLine( "\nPlease enter the url as command line parameter:" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_ResponseUri http://www.microsoft.com/net/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }
   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
