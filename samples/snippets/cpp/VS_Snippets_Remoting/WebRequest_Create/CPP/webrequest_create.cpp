/*System::Net::WebRequest::Create(Uri)

This program demonstrates the 'Create(Uri)' method of the 'WebRequest' class.
A new 'Uri' object is created to the specified Uri.
A new 'WebRequest' object is created to the 'specified' Uri by passing the 'Uri' object as parameter.
The response is obtained .
The HTML contents of the page of the requested Uri are displayed to the console.
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
      // Create a new 'Uri' object with the specified string.
      Uri^ myUri = gcnew Uri( "http://www.contoso.com" );
      // Create a new request to the above mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( myUri );
      // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
// </Snippet1>

      Stream^ streamResponse = myWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe contents of HTML Page are :  \n" );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuff,0,count );
         Console::Write( outputData );
         count = streamRead->Read( readBuff, 0, 256 );
      }
      streamResponse->Close();
      streamRead->Close();
      // Release the WebResponse Resource.
      myWebResponse->Close();
      Console::WriteLine( "\nPress 'Enter' key to continue................." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught!" );
      Console::WriteLine( "Source   : {0}", e->Source );
      Console::WriteLine( "Message  : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException Caught!" );
      Console::WriteLine( "Source   : {0} ", e->Source );
      Console::WriteLine( "Message  : {0} ", e->Message );
   }
}
