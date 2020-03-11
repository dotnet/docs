/*System::Net::HttpVersion::Version10
This program demonstrates the  'Version10' field of the 'HttpVersion' Class.
The 'ProtocolVersion'  property of 'HttpWebrequest' class identifies the Version of the Protocol being used.
A new 'HttpWebRequest' Object* is created.
Then the default value of 'ProtocolVersion' property is displayed to the console.
The 'Version10' field of the 'HttpVersion' class is assigned to the 'ProtocolVersion' property of the 'HttpWebRequest' Class.
The changed Version and the 'ProtocolVersion' of the response Object* are displayed.
*/

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;

int main()
{
   try
   {
// <Snippet1>
      // Create a 'HttpWebRequest' object.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( "http://www.microsoft.com" ) );
      Console::WriteLine( "\nThe 'ProtocolVersion' of the protocol before assignment is : {0}", myHttpWebRequest->ProtocolVersion );
      // Assign Version10 to ProtocolVersion.
      myHttpWebRequest->ProtocolVersion = HttpVersion::Version10;
      // Assign the response Object* of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      Console::WriteLine( "\nThe 'ProtocolVersion' of the protocol after  assignment is : {0}", myHttpWebRequest->ProtocolVersion );
      Console::WriteLine( "\nThe 'ProtocolVersion' of the response Object* is : {0}", myHttpWebResponse->ProtocolVersion );
// </Snippet1>
      Console::WriteLine( "\nPress 'Enter' Key to Continue.............." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught!" );
      Console::WriteLine( "Message : {0} ", e->Message );
      Console::WriteLine( "Source  : {0} ", e->Source );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException Caught!" );
      Console::WriteLine( "Source  : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
