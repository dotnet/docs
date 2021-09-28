// System::Net::HttpWebResponse::Method;System::Net::HttpWebResponse::Server
/* This program demonstrates the 'Method' and 'Server' properties of the 'HttpWebResponse' class.
It creates a Web request and queries for a response.It evaluates the response method used and the prints
the Web server name to the console*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;

void GetPage( String^ url )
{
// <Snippet1>
// <Snippet2>
   try
   {
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( url ) );
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      String^ method;
      method = myHttpWebResponse->Method;
      if ( String::Compare( method, "GET" ) == 0 )
      {
         Console::WriteLine( "\nThe 'GET' method was successfully invoked on the following Web Server : {0}",
            myHttpWebResponse->Server );
      }
      // Releases the resources of the response.
      myHttpWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException raised. The following error occurred : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
// </Snippet2>
// </Snippet1>
}

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the url as command line parameter:" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_Method_Server http://dotnet.microsoft.com/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }
   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
