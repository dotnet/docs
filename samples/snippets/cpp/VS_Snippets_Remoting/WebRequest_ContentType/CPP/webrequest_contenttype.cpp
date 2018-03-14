/*  System::Net::WebRequest::ContentType System::Net::WebRequest::ContentLength System::Net::WebRequest::GetRequestStream
This program demonstrates 'GetRequestStream' method , 'ContentLength' and 'ContentType' properties of
      'WebRequestClass'.
A new 'WebRequest' Object* is created and the method used for sending data is set to 'POST' method by setting
The 'Method' property to 'POST'.The 'ContentType' property is set to 'application/x-www-form-urlencoded'.
The 'ContentLength' property is set to the length of the Byte stream to be posted. A new 'Stream' Object* is
obtained from the 'GetRequestStream' method of the 'WebRequest' class.Data to be posted is requested from
the user and is posted using the stream Object*.The HTML contents of the page are then displayed to the
console after the Posted data is accepted by the URL.

Note: This program POSTs data to the Uri: http://www20.Brinkster::com/codesnippets/next.asp
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
// <Snippet3>
      // Create a new request to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com " );
      
      // Set the 'Method' property of the myWebrequest to POST.
      myWebRequest->Method = "POST";
      
      // Create a new string object to POST data to the above url.
      Console::WriteLine( "\nThe value of 'ContentLength' property before sending the data is {0}", myWebRequest->ContentLength );
      Console::WriteLine( "\nPlease enter the data to be posted to (http://www.contoso.com/codesnippets/next.asp) Uri" );
      String^ inputData = Console::ReadLine();
      String^ postData = String::Concat( "firstone= ", inputData );
      ASCIIEncoding^ encoding = gcnew ASCIIEncoding;
      array<Byte>^ byteArray = encoding->GetBytes( postData );
      
//<Snippet4>
      // Set the 'ContentType' property of the WebRequest.
      myWebRequest->ContentType = "application/x-www-form-urlencoded";
      
      // Set the 'ContentLength' property of the WebRequest.
      myWebRequest->ContentLength = byteArray->Length;
      Stream^ newStream = myWebRequest->GetRequestStream();
      newStream->Write( byteArray, 0, byteArray->Length );
      
      // Close the Stream object.
      newStream->Close();
      
      // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
//</Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>

      Console::WriteLine( "\nThe value of ContentLength property after sending the data is {0}", myWebRequest->ContentLength );
      Console::WriteLine( "\nThe String* entered has been succesfully posted to the Uri." );
      Console::WriteLine( "\nPlease wait for the response......." );
      Stream^ streamResponse = myWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe contents of the Html page are :  \n" );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuff,0,count );
         Console::WriteLine( outputData );
         count = streamRead->Read( readBuff, 0, 256 );
      }
      streamRead->Close();
      streamResponse->Close();
      
      // Release the resources of response Object*.
      myWebResponse->Close();
      Console::WriteLine( "\nPress 'Enter' Key to Continue........." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException raised!" );
      Console::WriteLine( "\n {0}", e->Message );
      Console::WriteLine( "\n {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
