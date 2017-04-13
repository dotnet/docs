// System::Net::WebClient::UploadData(String, Byte->Item[])

/*
This program demonstrates the 'UploadData(String, Byte->Item[])' method of S"WebClient" class.
It accepts an Uri and some String* content to be posted to the Uri. This String* is posted to the Uri
provided as input using the 'UploadData(String, Byte->Item[])' method. The custom made site responds back
with whatever was posted to it. The contents of the response are displayed to the console.

Note : The results described were obtained using a custom made site. This behaviour may not be the
same with all other sites. Also certain sites would not accept "Post" method thereby leading to
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
      Console::Write( "\nPlease enter the URI to post data to: " );
      String^ uriString = Console::ReadLine();
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      Console::WriteLine( "\nPlease enter the data to be posted to the URI {0}:", uriString );
      String^ postData = Console::ReadLine();
      // Apply ASCII Encoding to obtain the String* as a Byte array.
      array<Byte>^ postArray = Encoding::ASCII->GetBytes( postData );
      Console::WriteLine( "Uploading to {0} ...", uriString );
      myWebClient->Headers->Add( "Content-Type", "application/x-www-form-urlencoded" );
      
      //UploadData implicitly sets HTTP POST as the request method.
      array<Byte>^responseArray = myWebClient->UploadData( uriString, postArray );
      
      // Decode and display the response.
      Console::WriteLine( "\nResponse received was: {0}", Encoding::ASCII->GetString( responseArray ) );
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
