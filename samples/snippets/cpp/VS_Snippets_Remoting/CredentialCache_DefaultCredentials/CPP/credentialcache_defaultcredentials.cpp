

// System::Net::CredentialCache::DefaultCredentials.
/* This program demonstrates the 'DefaultCredentials' property of the 'CredentialCache'
class.
Creates an 'HttpWebRequest' Object* to access the local Uri S"http://localhost"(IIS documentation start page)
Assigns the static property 'DefaultCredentials' of 'CredentialCache' as 'Credentials' for the 'HttpWebRequest'
Object*. DefaultCredentials returns the system credentials for the current security context in which
the application is running. For a client-side application, these are usually the Windows credentials
(user name, password, and domain) of the user running the application.
These credentials are used internally to authenticate the request.
The html contents of the start page are displayed to the console.

Note: Make sure that S"Windows Authentication" has been set as  Directory Security settings
for default web site in IIS
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;

int main()
{
   try
   {
      // <Snippet1>
      // Ensure Directory Security settings for default web site in IIS is "Windows Authentication".
      String^ url = "http://localhost";

      // Create a 'HttpWebRequest' object with the specified url.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));

      // Assign the credentials of the logged in user or the user being impersonated.
      myHttpWebRequest->Credentials = CredentialCache::DefaultCredentials;

      // Send the 'HttpWebRequest' and wait for response.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      Console::WriteLine( "Authentication successful" );
      Console::WriteLine( "Response received successfully" );

      // </Snippet1>
      Console::WriteLine( "\nPress enter to continue" );
      Console::ReadLine();

      // Get the stream associated with the response object.
      Stream^ receiveStream = myHttpWebResponse->GetResponseStream();
      Encoding^ encode = System::Text::Encoding::GetEncoding( "utf-8" );

      // Pipe the stream to a higher level stream reader with the required encoding format.
      StreamReader^ readStream = gcnew StreamReader( receiveStream,encode );
      Console::WriteLine( "\r\nResponse stream received" );
      array<Char>^read = gcnew array<Char>(256);

      // Read 256 characters at a time.
      int count = readStream->Read( read, 0, 256 );
      Console::WriteLine( "HTML...\r\n" );
      while ( count > 0 )
      {
         // Dump the 256 characters on a string and display the string onto the console.
         String^ output = gcnew String( read,0,count );
         Console::Write( output );
         count = readStream->Read( read, 0, 256 );
      }
      Console::WriteLine( "" );

      // Release the resources of response Object*.
      myHttpWebResponse->Close();

      // Release the resources of stream Object*.
      readStream->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nException Raised. The following error occured : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following exception was raised : {0}", e->Message );
   }
}
