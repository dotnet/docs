// System::Net::WebClient::OpenRead

/*
This program demonstrates the 'OpenRead' method of 'WebClient' class.
It creates a URI to access a web resource. It then invokes 'OpenRead' tp obtain a 'Stream'
instance which is used to retrieve the web page data. The data read from the stream is then
displayed on the console.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;

int main()
{
   try
   {
      Console::Write( "\nPlease enter a URI (e.g. http://www.contoso.com): " );
      String^ uriString = Console::ReadLine();
      
// <Snippet1>
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      // Download home page data.
      Console::WriteLine( "Accessing {0} ...", uriString );
      // Open a stream to point to the data stream coming from the Web resource.
      Stream^ myStream = myWebClient->OpenRead( uriString );

      Console::WriteLine( "\nDisplaying Data :\n" );
      StreamReader^ sr = gcnew StreamReader( myStream );
      Console::WriteLine( sr->ReadToEnd() );
      
      // Close the stream.
      myStream->Close();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      // Display the exception.
      Console::WriteLine( "Webresource access failed!!! WebException : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      // Display the exception.
      Console::WriteLine( "The following general exception was raised: {0}", e->Message );
   }
}
