

/*
This program demonstrates the S"Remove" method of S"WebHeaderCollection" class.
It uses the S"Remove" method of S"WebHeaderCollection" to remove the 'Cache-Control' header from the request.
The 'Cache-Control' header is used to specify the directive that must be followed by all caching mechanisms
in the Request-Response chain. The 'no-cache' directive indicates that the caching mechanism must not resend
the cached response for a previous request with->Item[Out] validating* from  the origin server (HTTP version 1.1, RFC2616,
Sec 14.9)
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
void printHeaders( WebHeaderCollection^ headers )
{
   if ( headers->Count == 0 )
      Console::WriteLine( "\tNo Headers to Display" );

   for ( int i = 0; i < headers->Count; i++ )
      Console::WriteLine( "\t {0} : {1}", headers->AllKeys[ i ], headers[ i ] );
}

int main()
{
   // <Snippet1>
   try
   {
      // Create a web request for S"www.msn.com".
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.msn.com" ));

      // Get the headers associated with the request.
      WebHeaderCollection^ myWebHeaderCollection = myHttpWebRequest->Headers;

      // Set the Cache-Control header.
      myWebHeaderCollection->Set( "Cache-Control", "no-cache" );

      // Get the associated response for the above request.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());

      // Print the headers of the request to console.
      Console::WriteLine( "Print request headers after adding Cache-Control for first request:" );
      printHeaders( myHttpWebRequest->Headers );

      // Remove the Cache-Control header for the new request.
      myWebHeaderCollection->Remove( "Cache-Control" );

      // Get the response for the new request.
      myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());

      // Print the headers of the new request with->Item[Out] the* Cache-Control header.
      Console::WriteLine( "Print request headers after removing Cache-Control for the new request:" );
      printHeaders( myHttpWebRequest->Headers );
      myHttpWebResponse->Close();
   }
   // Catch exception if trying to remove a restricted header.
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( "Error : Trying to remove a restricted header" );
      Console::WriteLine( "ArgumentException is thrown. Message is : {0}", e->Message );
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException is thrown. Message is : {0}", e->Message );
      if ( e->Status == WebExceptionStatus::ProtocolError )
      {
         Console::WriteLine( "Status Code : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->StatusCode );
         Console::WriteLine( "Status Description : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->StatusDescription );
         Console::WriteLine( "Server : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->Server );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception is thrown. Message is : {0}", e->Message );
   }

   
   // </Snippet1>
}
