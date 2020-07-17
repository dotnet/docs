// System::Net::HttpWebResponse::Headers

/* This program demonstrates the 'Headers' property of the 'HttpWebResponse' class
It creates a web request and queries for a response.It then displays all the response headers
onto the console. */
#using <System.dll>

using namespace System;
using namespace System::Net;

void GetPage( String^ url )
{
   try
   {
      // <Snippet1>
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));
      
      // Sends the HttpWebRequest and waits for response.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      
      // Displays all the headers present in the response received from the URI.
      Console::WriteLine( "\r\nThe following headers were received in the response:" );
      
      // Displays each header and its key associated with the response.
      for ( int i = 0; i < myHttpWebResponse->Headers->Count; ++i )
         Console::WriteLine( "\nHeader Name: {0}, Value : {1}",
            myHttpWebResponse->Headers->Keys[ i ],
            myHttpWebResponse->Headers[ (System::Net::HttpRequestHeader)i ] );
      
      // Releases the resources of the response.
      myHttpWebResponse->Close();
      // </Snippet1>
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

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the url as command line parameter:" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_Headers http://dotnet.microsoft.com/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
