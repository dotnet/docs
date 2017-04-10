/*System::Net::HttpWebRequest::AllowWriteStreamBuffering
This program demonstrates 'AllowWriteStreamBuffering' property of 'HttpWebRequestClass'.
A new 'HttpWebRequest' Object* is created.
The 'AllowWriteStreamBuffering' property value is set to false.
If the 'AllowWriteStreamBuffering' is set to false,
then 'ContentLength' property should be set to the length of data to be posted before posting the data
else the Http Status(411) Length required is returned.
Data to be posted to the Uri is requested from the user.
The 'Method' property is set to POST to be able to post data to the Uri.
The 'GetRequestStream' method of the 'HttpWebRequest' class returns a stream Object*.
This stream Object* is used to write data to the Uri.
The HTML contents of the page are displayed to the console after the posted data is accepted by the URL

Note:This program posts data to the Uri : http://www20.brinkster.com/codesnippets/next.asp.
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
      // Create a new 'HttpWebRequest' object to the mentioned Uri.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( "http://www.contoso.com/codesnippets/next.asp" ) );
      // Set AllowWriteStreamBuffering to 'false'.
      myHttpWebRequest->AllowWriteStreamBuffering = false;
      Console::WriteLine( "\nPlease Enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) uri:" );
      String^ inputData = Console::ReadLine();
      String^ postData = String::Concat( "firstone= ", inputData );
      // Set 'Method' property of 'HttpWebRequest' class to POST.
      myHttpWebRequest->Method = "POST";
      ASCIIEncoding^ encodedData = gcnew ASCIIEncoding;
      array<Byte>^ byteArray = encodedData->GetBytes( postData );
      // Set 'ContentType' property of the 'HttpWebRequest' class to S"application/x-www-form-urlencoded".
      myHttpWebRequest->ContentType = "application/x-www-form-urlencoded";
      // If the AllowWriteStreamBuffering property of HttpWebRequest is set to false, the contentlength has to be set to length of data to be posted else Exception(411) is raised.
      myHttpWebRequest->ContentLength = byteArray->Length;
      Stream^ newStream = myHttpWebRequest->GetRequestStream();
      newStream->Write( byteArray, 0, byteArray->Length );
      newStream->Close();
      Console::WriteLine( "\nData has been posted to the Uri\n\nPlease wait for the response.........." );
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
// </Snippet1>
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe contents of the Html page are :  " );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuff,0,count );
         Console::WriteLine( outputData );
         count = streamRead->Read( readBuff, 0, 256 );
      }
      streamResponse->Close();
      streamRead->Close();
      // Release the HttpWebResponse Resource.
      myHttpWebResponse->Close();
      Console::WriteLine( "\nPress 'Enter' Key to Continue................." );
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught!" );
      Console::WriteLine( "Message : {0}", e->Message );
      Console::WriteLine( "\n(The 'ContentLength' property of 'HttpWebRequest' is not set after 'AllowWriteStreamBuffering' is set to 'false'.)" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException Caught!" );
      Console::WriteLine( "Source  : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
