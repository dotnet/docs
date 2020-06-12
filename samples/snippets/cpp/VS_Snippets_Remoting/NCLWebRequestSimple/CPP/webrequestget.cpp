

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Text;
int main()
{
   
   // <Snippet2>
   // Create a request for the URL.   
   WebRequest^ request = WebRequest::Create( "http://www.contoso.com/default.html" );
   
   // If required by the server, set the credentials.
   request->Credentials = CredentialCache::DefaultCredentials;
   
   // Get the response.
   HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());
   
   // </Snippet2>
   // Display the status.
   Console::WriteLine( response->StatusDescription );
   
   // Get the stream containing content returned by the server.
   Stream^ dataStream = response->GetResponseStream();
   
   // Open the stream using a StreamReader for easy access.
   StreamReader^ reader = gcnew StreamReader( dataStream );
   
   // Read the content.
   String^ responseFromServer = reader->ReadToEnd();
   
   // Display the content.
   Console::WriteLine( responseFromServer );
   
   // Cleanup the streams and the response.
   reader->Close();
   dataStream->Close();
   response->Close();
}

// </Snippet1>
