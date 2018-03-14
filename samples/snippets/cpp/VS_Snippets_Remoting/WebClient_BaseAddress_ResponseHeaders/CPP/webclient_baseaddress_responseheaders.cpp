// System::Net::WebClient::BaseAddress; System::Net::WebClient::ResponseHeaders

/*This program demonstrates the 'BaseAddress' and 'ResponseHeaders' property of 'WebClient' class.
It accepts the base Uri from the user and assigns it to the 'BaseAddress' property of the
'WebClient' class.It then invokes 'DownloadFile' for the specific web page requested by the
user. WebClient internally combines the 'BaseAddress' and specific page name to retrieve the page.

The 'ResponseHeaders' property is a 'WebHeaderCollection' that contains the
header information of the response received from the server.This is displayed to the console.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;

int main()
{
   try
   {
      Console::Write( "\nPlease enter a Url {e.g. : http://www.microsoft.com}" );
      String^ hostUri = Console::ReadLine();
      Console::Write( "\nPlease enter the specific web page you require {e.g. : windows/default.asp} : " );
      String^ uriSuffix = Console::ReadLine();
      
// <Snippet1>
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      
      // Set the BaseAddress of the Web Resource in the WebClient.
      myWebClient->BaseAddress = hostUri;
      Console::WriteLine( "Downloading from {0}/ {1}", hostUri, uriSuffix );
      Console::WriteLine( "\nPress Enter key to continue" );
      Console::ReadLine();
      
      // Download the target Web Resource into a Byte array.
      array<Byte>^ myDatabuffer = myWebClient->DownloadData( uriSuffix );
      
      // Display the downloaded data.
      String^ download = Encoding::ASCII->GetString( myDatabuffer );
      Console::WriteLine( download );
      Console::WriteLine( "Download of {0}{1} was successful.", myWebClient->BaseAddress, uriSuffix );
// </Snippet1>

// <Snippet2>
      // Obtain the WebHeaderCollection instance containing the header name/value pair from the response.
      WebHeaderCollection^ myWebHeaderCollection = myWebClient->ResponseHeaders;
      Console::WriteLine( "\nDisplaying the response headers\n" );
      
      // Loop through the ResponseHeaders and display the header name/value pairs.
      for ( int i = 0; i < myWebHeaderCollection->Count; i++ )
      {
         Console::WriteLine( "\t{0} = {1}", myWebHeaderCollection->GetKey( i ),
            myWebHeaderCollection->Get( i ) );
      }
// </Snippet2>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "The following WebException was raised: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following Exception was raised: {0}", e->Message );
   }
}
