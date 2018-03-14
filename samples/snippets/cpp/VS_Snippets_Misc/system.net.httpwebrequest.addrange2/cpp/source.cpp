/*System::Net::HttpWebRequest->AddRange(int, int)
This program demonstrates 'AddRange(int, int)' method of 'HttpWebRequest class.
A new 'HttpWebRequest' Object* is created.The number of characters of the response to be received can be
restricted by the 'AddRange' method.By calling 'AddRange(50, 150)' on the 'HttpWebRequest' Object* the content
of the response page is restricted from the 50th character to 150th charater.The response of the request is
obtained and displayed to the console.
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
      // Create a New 'HttpWebRequest' object.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( "http://www.contoso.com" ) );
      myHttpWebRequest->AddRange( 50, 150 );
      Console::WriteLine("Call AddRange(50, 150)");
			Console::Write("Resulting Request Headers: ");
			Console::WriteLine(myHttpWebRequest->Headers);

      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );

      // Displays the headers in the response received
      Console::Write("Resulting Response Headers: ");
			Console::WriteLine(myHttpWebResponse->Headers);

      // Display the contents of the page to the console.
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuffer = gcnew array<Char>(256);
      int count = streamRead->Read( readBuffer, 0, 256 );
      Console::WriteLine( "\nThe HTML contents of the page from 50th to 150 charaters are :\n  " );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuffer,0,count );
         Console::WriteLine( outputData );
         count = streamRead->Read( readBuffer, 0, 256 );
      }
      streamRead->Close();
      streamResponse->Close();
      myHttpWebResponse->Close();
// </Snippet1>
      Console::WriteLine( "\nPress 'Enter' Key to Continue..........." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught!" );
      Console::WriteLine( "Message : {0} ", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException Caught!" );
      Console::WriteLine( "Message : {0} ", e->Message );
   }
}
