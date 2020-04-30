

/*
This program demonstrates 'Item(int)' properties of 'CookieCollection' class.

This program uses an internal site called "CookiesServer.aspx". The program creates a 'HttpWebRequest'
object with the 'URL' taken from command line argument. When no cookies are initially sent to
the server, it responds with a specific page querying the client for information. The client queries
this information from the user and sends it to the server in the second request. This information is
used by the server to not only structure the page sent subsequently but also construct some cookies to be
set by the client, for future requests. The response and the  cookies that are sent from the server are
displayed to the console.

Note: This program requires the "CookiesServer.aspx" server to be running before the execution of this
program.Please refer the "ReadmeCookiesServer.txt" file for setting up the server.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Text::RegularExpressions;
void DisplayCookies( CookieCollection^ cookies )
{
   // <Snippet1>
   // Get the cookies in the 'CookieCollection' object using the 'Item' property.
   // The 'Item' property in C++ is implemented through Indexers. 
   // The class that implements indexers is usually a collection of other objects. 
   // This class provides access to those objects with the '<class-instance>[i]' syntax. 
   try
   {
      if ( cookies->Count == 0 )
      {
         Console::WriteLine( "No cookies to display" );
         return;
      }

      for ( int j = 0; j < cookies->Count; j++ )
         Console::WriteLine( "{0}", cookies[ j ] );
      Console::WriteLine( "" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised.\nError : {0}", e->Message );
   }
   // </Snippet1>
}

void GetPage( Uri^ requestUri )
{
   try
   {
      array<Byte>^output = gcnew array<Byte>(120);
      Stream^ myStream;
      Encoding^ asciiEncoding = gcnew ASCIIEncoding;

      // Create the request.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( requestUri ));

      // Get the response without any cookies sent to the server.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      String^ usrName;
      String^ dateBirth;
      String^ placeBirth;

      // Get the information from the user as requested by the server and send it over to the server.
      myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( requestUri ));
      myHttpWebRequest->Method = "POST";
      myHttpWebRequest->ContentType = "application/x-www-form-urlencoded";
      Console::WriteLine( "\nEnter the values to be sent to the server :\n" );
      Console::Write( "UserName : " );
      usrName = Console::ReadLine();
      Console::Write( "\nDateOfBirth [dd/mm/yyyy]: " );
      dateBirth = Console::ReadLine();
      Regex^ regex = gcnew Regex( "/" );
      String^ convertDate = regex->Replace( dateBirth, "%2F" );
      Console::Write( "\nPlaceOfBirth : " );
      placeBirth = Console::ReadLine();
      Console::WriteLine( "" );
      output = asciiEncoding->GetBytes( String::Format( "UserName={0}&DateOfBirth={1}&PlaceOfBirth={2}&__EVENTTARGET=PlaceOfBirth&__EVENTARGUMENT=", usrName, convertDate, placeBirth ) );
      myHttpWebRequest->ContentLength = output->Length;
      myStream = myHttpWebRequest->GetRequestStream();
      myStream->Write( output, 0, output->Length );
      myStream->Close();
      myHttpWebResponse->Close();

      // Get the response.
      myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());

      // Output the response to the console.
      myStream = myHttpWebResponse->GetResponseStream();
      Console::WriteLine( "Displaying the contents of the page of '{0}' site:", requestUri );
      Console::WriteLine( "" );
      int bytesRead = 0;
      while ( (bytesRead = myStream->Read( output, 0, output->Length )) != 0 )
            Console::Write( asciiEncoding->GetString( output, 0, bytesRead ) );
      Console::WriteLine( "" );
      Console::WriteLine( "\nDisplaying the cookies in the response : " );
      Console::WriteLine( "" );
      DisplayCookies( myHttpWebResponse->Cookies );
      myHttpWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException raised.\nError : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised.\nError : {0}", e->Message );
   }

}

void printUsage()
{
   Console::WriteLine( "Usage : " );
   Console::WriteLine( "CookieCollection_Item_2 <urlname>" );
   Console::WriteLine( "<urlname> is the name of the CookiesServer.aspx site installed locally" );
   Console::WriteLine( "\nExample : CookieCollection_Item_2 http://www.MyServer.com/CookiesServer.aspx" );
}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   try
   {
      if ( args->Length < 2 )
      {
         printUsage();
         return 0;
      }
      GetPage( gcnew Uri( args[ 1 ] ) );
   }
   catch ( UriFormatException^ e ) 
   {
      Console::WriteLine( "UriFormatException raised.\nError : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised.\nError : {0}", e->Message );
   }
}
