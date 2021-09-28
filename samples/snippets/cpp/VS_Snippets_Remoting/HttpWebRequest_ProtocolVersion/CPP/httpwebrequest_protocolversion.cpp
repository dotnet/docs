/* System::Net::HttpWebRequest::ProtocolVersion
This Program demonstrates the  'ProtocolVersion' property of the 'HttpWebRequest' Class.
The 'ProtocolVersion' is a property that identifies the Version of the Protocol being used.
A new 'HttpWebRequest' Object* is created.Then the default version, being used is displayed onto
the console.It is then set to another version and displayed to the Console::The HTML contents
of the page of the requested Uri are printed to the console.
Note:Here the 'ProtocolVersion' property displays the ProtocolVersion being used.
*/

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
      // Create a new 'HttpWebRequest' Object to the mentioned URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( "http://www.microsoft.com" ) );
      // Use the existing 'ProtocolVersion' , and display it onto the console.
      Console::WriteLine( "\nThe 'ProtocolVersion' of the protocol used is {0}", myHttpWebRequest->ProtocolVersion );
      // Set the 'ProtocolVersion' property of the 'HttpWebRequest' to 'Version1::0' .
      myHttpWebRequest->ProtocolVersion = HttpVersion::Version10;
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      Console::WriteLine( "\nThe 'ProtocolVersion' of the protocol changed to {0}", myHttpWebRequest->ProtocolVersion );
      Console::WriteLine( "\nThe protocol version of the response Object* is {0}", myHttpWebResponse->ProtocolVersion );
// </Snippet1>
      Console::WriteLine( "\nPress any Key to Continue.............." );
      Console::Read();
      Console::Read();
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe contents of the HTML Page are  :" );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuff,0,count );
         Console::Write( outputData );
         count = streamRead->Read( readBuff, 0, 256 );
      }
      streamResponse->Close();
      streamRead->Close();
      // Release the HttpWebResponse Resource.
      myHttpWebResponse->Close();
      Console::WriteLine( "\nPress any Key to Continue.............." );
      Console::Read();
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException raised!" );
      Console::WriteLine( "\nMessage: {0} ", e->Message );
      Console::WriteLine( "\nStatus: {0} ", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException raised!" );
      Console::WriteLine( "\nSource : {0}", e->Source );
      Console::WriteLine( "\nMessage : {0}", e->Message );
   }
}
