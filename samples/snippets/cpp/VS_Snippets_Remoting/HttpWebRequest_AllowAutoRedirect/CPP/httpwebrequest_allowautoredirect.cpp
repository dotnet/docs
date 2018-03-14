/* System::Net::HttpWebRequest::AllowAutoRedirect System::Net::HttpWebRequest->Address
This program demonstrates  'AllowAutoRedirect' and 'Address' properties of 'HttpWebRequest' Class.
A new 'HttpWebRequest' Object* is created. The 'AllowAutoredirect' property which redirects a page automatically
to the new Uri is set to true.Using the 'Address' property, the address of the 'Responding Uri' is printed to
console.The contents of the redirected page are displayed to the console.
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
// <Snippet2>
      // Create a new HttpWebRequest Object to the mentioned URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( "http://www.contoso.com" ) );
      myHttpWebRequest->MaximumAutomaticRedirections = 1;
      myHttpWebRequest->AllowAutoRedirect = true;
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
// </Snippet2>
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe contents of Html Page are :  " );
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
      Console::WriteLine( "\nThe Requested Uri is {0}", myHttpWebRequest->RequestUri );
      Console::WriteLine( "\nThe Actual Uri responding to the request is \n {0}", myHttpWebRequest->Address );
// </Snippet1>
      Console::WriteLine( "\nPress any Key to Continue.........." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException raised!" );
      Console::WriteLine( "\nMessage: {0}", e->Message );
      Console::WriteLine( "\nStatus: {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised!" );
      Console::WriteLine( "\nSource : {0}", e->Source );
      Console::WriteLine( "\nMessage : {0}", e->Message );
   }
}
