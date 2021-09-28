

// SampleID="NCLResponse1"
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;
using namespace System::IO;

// Specify the URL to receive the request.
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   HttpWebRequest^ request = dynamic_cast<HttpWebRequest^>(WebRequest::Create( args[ 1 ] ));
   
   // Set some reasonable limits on resources used by this request
   request->MaximumAutomaticRedirections = 4;
   request->MaximumResponseHeadersLength = 4;
   
   // Set credentials to use for this request.
   request->Credentials = CredentialCache::DefaultCredentials;
   HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());
   Console::WriteLine( "Content length is {0}", response->ContentLength );
   Console::WriteLine( "Content type is {0}", response->ContentType );
   
   // Get the stream associated with the response.
   Stream^ receiveStream = response->GetResponseStream();
   
   // Pipes the stream to a higher level stream reader with the required encoding format. 
   StreamReader^ readStream = gcnew StreamReader( receiveStream,Encoding::UTF8 );
   Console::WriteLine( "Response stream received." );
   Console::WriteLine( readStream->ReadToEnd() );
   response->Close();
   readStream->Close();
}

/*
The output from this example will vary depending on the value passed into Main 
but will be similar to the following:

Content length is 1542
Content type is text/html; charset=utf-8
Response stream received.
<html>
...
</html>

*/
// </Snippet1>
