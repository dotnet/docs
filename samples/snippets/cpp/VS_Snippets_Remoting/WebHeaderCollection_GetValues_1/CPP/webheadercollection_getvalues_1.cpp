

/*
This program demonstrate's the 'GetValues(String*)' method of 'WebHeaderCollection' class.

The program creates a 'HttpWebRequest' Object* from the specified URL and gets the response from it. The
headers of the response is assigned to a 'WeHeaderCollection' Object* and all the values associated with
the corresponding headers in the response are displayed to the console.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
int main()
{
   try
   {
      // <Snippet1>
      // Create a web request for S"www.msn.com".
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.msn.com" ));
      myHttpWebRequest->Timeout = 1000;

      // Get the associated response for the above request.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());

      // Get the headers associated with the response.
      WebHeaderCollection^ myWebHeaderCollection = myHttpWebResponse->Headers;
      for ( int i = 0; i < myWebHeaderCollection->Count; i++ )
      {
         String^ header = myWebHeaderCollection->GetKey( i );
         array<String^>^values = myWebHeaderCollection->GetValues( header );
         if ( values->Length > 0 )
         {
            Console::WriteLine( "The values of {0} header are : ", header );
            for ( int j = 0; j < values->Length; j++ )
               Console::WriteLine( "\t {0}", values[ j ] );
         }
         else
                  Console::WriteLine( "There is no value associated with the header" );
      }
      myHttpWebResponse->Close();
      // </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException raised : {0}", e->Message );
      if ( e->Status == WebExceptionStatus::ProtocolError )
      {
         Console::WriteLine( "Status Code : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->StatusCode );
         Console::WriteLine( "Status Description : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->StatusDescription );
         Console::WriteLine( "Server : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->Server );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\n Exception raised : {0}", e->Message );
   }
}
