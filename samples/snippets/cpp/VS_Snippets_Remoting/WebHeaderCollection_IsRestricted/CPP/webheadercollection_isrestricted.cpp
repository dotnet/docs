

/*This program demonstrates the S"IsRestricted" method of S"WebHeaderCollection".
It checks if the first header returned in the response is a restricted header or not.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
int main()
{
   // <Snippet1>
   try
   {
      // Create a web request for S"www.msn.com".
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.msn.com" ));

      // Get the associated response for the above request.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());

      // Get the headers associated with the response.
      WebHeaderCollection^ myWebHeaderCollection = myHttpWebResponse->Headers;
      for ( int i = 0; i < myWebHeaderCollection->Count; i++ )
      {
         // Check if the first response header is restriced.
         if ( WebHeaderCollection::IsRestricted( dynamic_cast<String^>(myWebHeaderCollection->AllKeys[ i ]) ) )
                  Console::WriteLine( "' {0}' is a restricted header", myWebHeaderCollection->AllKeys[ i ] );
         else
                  Console::WriteLine( "' {0}' is not a restricted header", myWebHeaderCollection->AllKeys[ i ] );
      }
      myHttpWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException is thrown.\nMessage is: {0}", e->Message );
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

