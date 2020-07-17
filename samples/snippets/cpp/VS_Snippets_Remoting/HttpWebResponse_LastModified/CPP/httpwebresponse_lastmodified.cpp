// System::Net::HttpWebResponse::LastModified
/* This program demonstrates the 'LastModified' property of the 'HttpWebResponse' class
It creates a web request and queries for a response.The program checks
if the entity requested was modified any time today.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

void GetPage( String^ url )
{
   try
   {
// <Snippet1>
      Uri^ myUri = gcnew Uri( url );
      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( myUri ) );
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      if ( myHttpWebResponse->StatusCode == HttpStatusCode::OK )
      {
         Console::WriteLine( "\r\nRequest succeeded and the requested information is in the response , Description : {0}",
            myHttpWebResponse->StatusDescription );
      }
      DateTime today = DateTime::Now;
      // Uses the LastModified property to compare with today's date.
      if ( DateTime::Compare( today, myHttpWebResponse->LastModified ) == 0 )
      {
         Console::WriteLine( "\nThe requested URI entity was modified today" );
      }      
      else if ( DateTime::Compare( today, myHttpWebResponse->LastModified ) == 1 )
      {
         Console::WriteLine( "\nThe requested URI was last modified on: {0}",
            myHttpWebResponse->LastModified );
      }
      // Releases the resources of the response.
      myHttpWebResponse->Close();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException Raised. The following error occurred : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
}

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease type the url as command line parameter:" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "HttpWebResponse_LastModified http://dotnet.microsoft.com/" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
