// System::Net::WebClient::DownloadData; System::Net::WebClient::WebClient

/*
This program demonstrates the 'DownloadData' method and 'WebClient()' constructor of 'WebClient' class.
It creates a URI to access a web resource. The Uri can point
to any text or binary web resource, like images etc. The 'DownloadData' method then downloads
the required text/html homepage into a Byte array. The downloaded data is displayed on the Console.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;

int main()
{
   try
   {
// <Snippet1>
// <Snippet2>
      Console::Write( "\nPlease enter a URI (e.g. http://www.contoso.com): " );
      String^ remoteUri = Console::ReadLine();
      
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      // Download home page data.
      Console::WriteLine( "Downloading {0}", remoteUri );
      // Download the Web resource and save it into a data buffer.
      array<Byte>^ myDataBuffer = myWebClient->DownloadData( remoteUri );
      
      // Display the downloaded data.
      String^ download = Encoding::ASCII->GetString( myDataBuffer );
      Console::WriteLine( download );

      Console::WriteLine( "Download successful." );
// </Snippet1>
// </Snippet2>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "Download failed!!! WebException : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following general exception was raised: {0}", e->Message );
   }
}
