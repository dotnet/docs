// System::Net::WebClient::UploadValues(String, NameValueCollection)

/*
This program demonstrates the 'UploadValues(String, NameValueCollection)' method of S"WebClient" class.
It accepts an Uri::Forms a 'NameValueCollection' instance using
a set of pre-defined name-value pairs. These are posted to the Uri provided as input using the
'UploadValues(String, NameValueCollection)'method. The custom made site responds back
with whatever was posted to it. This is displayed to the console.

Note : The results described were obtained using a custom made site. This behaviour may not be the
same with all other sites. Also certain sites would not accept S"Post" method thereby leading to
an error.It is advisable to construct a site using files accompanying this and provide
url name of this site to the program.
*/

#using <System.dll>

using namespace System;
using namespace System::Collections::Specialized;
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
      
      // Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
      NameValueCollection^ myNameValueCollection = gcnew NameValueCollection;

      Console::WriteLine( "Please enter the following parameters to be posted to the URL" );
      Console::Write( "Name: " );
      String^ name = Console::ReadLine();

      Console::Write( "Age: " );
      String^ age = Console::ReadLine();

      Console::Write( "Address: " );
      String^ address = Console::ReadLine();
      
      // Add necessary parameter/value pairs to the name/value container.
      myNameValueCollection->Add( "Name", name );
      myNameValueCollection->Add( "Address", address );
      myNameValueCollection->Add( "Age", age );

      Console::WriteLine( "\nUploading to {0} ...", uriString );
      // 'The Upload(String, NameValueCollection)' implicitly method sets HTTP POST as the request method.
      array<Byte>^ responseArray = myWebClient->UploadValues( uriString, myNameValueCollection );
      
      // Decode and display the response.
      Console::WriteLine( "\nResponse received was :\n {0}", Encoding::ASCII->GetString( responseArray ) );
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
