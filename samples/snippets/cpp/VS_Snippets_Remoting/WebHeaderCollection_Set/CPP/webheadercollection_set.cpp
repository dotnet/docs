

/* This program demonstrates the S"Set" method of S"WebHeaderCollection" class.
It sets the value of the 'Cache-Control' header in the request to S"no-cache". The 'Cache-Control' header
is used to specify the directive that must be followed by all caching mechanisms in the Request-Response chain.
The 'no-cache' directive indicates that the caching mechanism must not resend the cached  response for a
previous request with->Item[Out] validating* from  the origin server (HTTP version 1.1, RFC2616, Sec 14.9).
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
void PrintHeaders( WebHeaderCollection^ headers )
{
   Console::WriteLine( "Printing Headers : " );
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

      // Set the Cache-Control header in the request.
      myWebHeaderCollection->Set( "Cache-Control", "no-cache" );

      // Get the associated response for the above request.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      Console::WriteLine( "Headers after 'Set' method is used on Cache-Control :" );

      // Print the headers for the request.
      PrintHeaders( myWebHeaderCollection );
      myHttpWebResponse->Close();
   }
   // Catch exception if trying to set a restricted header.
   catch ( ArgumentException^ e ) 
   {
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
