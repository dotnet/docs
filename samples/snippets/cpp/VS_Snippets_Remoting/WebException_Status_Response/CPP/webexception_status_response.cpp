/* This program demonstrates the S"Status" and the S"Response" property of S"WebException" class.
It tries to access an invalid site and displays the status code and status description of the
resultant  exception that is raised.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

int main()
{
// <Snippet1>
// <Snippet2>
   try
   {
      // Create a web request for an unknown server (this raises the WebException).
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)(WebRequest::Create( "http://unknown.unknown.com" ));
      
      // Get the associated response for the above request.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)(myHttpWebRequest->GetResponse());
      myHttpWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "This program is expected to throw WebException on successful run." +
         "\n\nException Message : " + e->Message );
      if ( e->Status == WebExceptionStatus::ProtocolError )
      {
         Console::WriteLine( "Status Code: {0}", ( (HttpWebResponse^)(e->Response) )->StatusCode );
         Console::WriteLine( "Status Description: {0}", ( (HttpWebResponse^)(e->Response) )->StatusDescription );
      }
// </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
// </Snippet1>
}
