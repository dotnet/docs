// System::Net::WebClientOpenWrite(String, String)

/*
This program demonstrates the 'OpenWrite(String, String)' method of S"WebClient" class.
It accepts an Uri and some String* content to be posted to the Uri. The
program makes a call to 'OpenWrite(String, String)' method and obtains a S"Stream" instance
This stream is used to post data to the site.

Note : Behaviour of this program may not be the same with all other sites. Also certain
sites would not accept S"Post" method thereby leading to an error.It is advisable
to construct a site using files accompanying this and provide
url name of this site to the program.
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
      String^ uriString;
      Console::Write( "\nPlease enter the URI to post data to: " );
      uriString = Console::ReadLine();
      Console::WriteLine( "\nPlease enter the data to be posted to the URI {0}:", uriString );
      String^ postData = Console::ReadLine();
      // Apply ASCII encoding to obtain an array of bytes .
      array<Byte>^ postArray = Encoding::ASCII->GetBytes( postData );
      
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;

      Console::WriteLine( "Uploading to {0} ...", uriString );
      Stream^ postStream = myWebClient->OpenWrite( uriString, "POST" );
      postStream->Write( postArray, 0, postArray->Length );
      
      // Close the stream and release resources.
      postStream->Close();
      Console::WriteLine( "\nSuccessfully posted the data." );
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
