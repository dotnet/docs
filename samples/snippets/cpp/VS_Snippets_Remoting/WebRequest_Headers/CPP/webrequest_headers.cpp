/*System::Net::WebRequest::Headers
* This program demonstrates the 'Headers' property of 'WebRequest' Class.
A new 'WebRequest' Object* is created.The (name, value) collection of the HTTP Headers are displayed to the
console.The contents of the HTML page of the requested URI are displayed to the console. */

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Text;

int main()
{
   try
   {
// <Snippet1>
      // Create a new request to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      
      // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Release the resources of response object.
      myWebResponse->Close();
      Console::WriteLine( "\nThe HttpHeaders are \n {0}", myWebRequest->Headers );
// </Snippet1>

      Console::WriteLine( "\nPress Enter Key to Continue........." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "Exception raised!" );
      Console::WriteLine( "\n {0}", e->Message );
      Console::WriteLine( "\n {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised!" );
      Console::WriteLine( "Source : {0} ", e->Source );
      Console::WriteLine( "Message : {0} ", e->Message );
   }
}
