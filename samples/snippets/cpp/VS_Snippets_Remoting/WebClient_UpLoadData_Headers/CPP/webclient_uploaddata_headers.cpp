// System::Net::WebClient::UplodaData(String, String, Byte->Item[]); System::Net::WebClient::Headers

/*
This program demonstrates the 'UploadData(String, String, Byte->Item[])' method and 'Headers' property of
'WebClient' class.It accepts an Uri and some String* content to be posted to the Uri. This String*
is posted to the Uri provided as input using the 'UploadData(String, String, Byte->Item[])' method.
The 'Headers' property is used to set the S"Content-Type" header to S"application/x-www-form-urlencoded".
The custom made site responds back with whatever was posted to it.
The contents of the response are displayed to the console.

Note : The results described were obtained using a custom made site. This behaviour may not be the
same with all other sites. Also certain sites would not support the S"Post" method thereby leading to
an error.It is advisable to construct a site using files accompanying this and provide
url name of this site to the program.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;

int main()
{
   try
   {
// <Snippet1>
// <Snippet2>
      String^ uriString;
      Console::Write( "\nPlease enter the URI to post data to {for example, http://www.contoso.com}: " );
      uriString = Console::ReadLine();

      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      Console::WriteLine( "\nPlease enter the data to be posted to the URI {0}:", uriString );
      String^ postData = Console::ReadLine();
      myWebClient->Headers->Add( "Content-Type", "application/x-www-form-urlencoded" );

      // Displays the headers in the request
      Console::Write( "Resulting Request Headers: ");
      Console::WriteLine(myWebClient->Headers);
      
      // Apply ASCII Encoding to obtain the String^ as a Byte array.
      array<Byte>^ byteArray = Encoding::ASCII->GetBytes( postData );
      Console::WriteLine( "Uploading to {0} ...", uriString );
      // Upload the input String* using the HTTP 1.0 POST method.
      array<Byte>^responseArray = myWebClient->UploadData( uriString, "POST", byteArray );
      // Decode and display the response.
      Console::WriteLine( "\nResponse received was {0}",
         Encoding::ASCII->GetString( responseArray ) );
// </Snippet2>
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}
