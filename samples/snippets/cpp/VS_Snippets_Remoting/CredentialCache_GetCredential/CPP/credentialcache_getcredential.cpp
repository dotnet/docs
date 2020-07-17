

// System::Net::CredentialCache::GetCredential
/*This program demontrates the 'GetCredential' method of the CredentialCache class.It takes an URL
creates a 'WebRequest' Object* for the Url. The program stores a known set of credentials in a credential cache.
'GetCredential' will then retrieve the credentials for the requested Uri.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Collections;

// <Snippet1>
void Display( NetworkCredential^ credential )
{
   Console::WriteLine( "\nThe credentials are:" );
   Console::WriteLine( "\nUsername : {0} , Password : {1} , Domain : {2}", credential->UserName, credential->Password, credential->Domain );
}

void GetPage( String^ url, String^ userName, String^ password, String^ domainName )
{
   try
   {
      CredentialCache^ myCredentialCache = gcnew CredentialCache;

      // Dummy names used as credentials.
      myCredentialCache->Add( gcnew Uri( "http://microsoft.com/" ), "Basic", gcnew NetworkCredential( "user1","passwd1","domain1" ) );
      myCredentialCache->Add( gcnew Uri( "http://msdn.com/" ), "Basic", gcnew NetworkCredential( "user2","passwd2","domain2" ) );
      myCredentialCache->Add( gcnew Uri( url ), "Basic", gcnew NetworkCredential( userName,password,domainName ) );

      // Create a webrequest with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( url );

      // Call 'GetCredential' to obtain the credentials specific to our Uri.
      NetworkCredential^ myCredential = myCredentialCache->GetCredential( gcnew Uri( url ), "Basic" );
      Display( myCredential );

      // Associating only our credentials.
      myWebRequest->Credentials = myCredential;

      // Sends the request and waits for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();

      // Process response here.
      Console::WriteLine( "\nResponse Received." );
      myWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      if ( e->Response != nullptr )
            Console::WriteLine( "\r\nFailed to obtain a response. The following error occurred : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->StatusDescription );
      else
            Console::WriteLine( "\r\nFailed to obtain a response. The following error occurred : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following exception was raised : {0}", e->Message );
   }
}
// </Snippet1>

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 4 )
   {
      Console::WriteLine( "\n Usage:" );
      Console::WriteLine( "\n CredentialCache_GetCredential <url> <User Name> <Password> <Domain Name>" );
      Console::WriteLine( "\n Example: CredentialCache_GetCredential http://www.microsoft.com  Catherine cath$ microsoft" );
   }
   else
   if ( (args->Length == 4) )
   {
      GetPage( args[ 0 ], args[ 1 ], args[ 2 ], args[ 3 ] );
   }
   else
   {
      Console::WriteLine( "\nInvalid arguments." );
      return 0;
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
   return 0;
}
