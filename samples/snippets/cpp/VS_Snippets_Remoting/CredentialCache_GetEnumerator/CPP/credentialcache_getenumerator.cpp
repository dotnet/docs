

// System::Net::CredentialCache::GetEnumerator
/*This program demontrates the  'GetEnumerator' method of the CredentialCache class.
It takes an URL, creates a 'WebRequest' Object* for the Url. The program stores a known set of credentials
in a credential cache which is then bound to the request. If the url requested has it's credentials in the cache
the response will be OK . 'GetEnumerator' method is used to enlist all the credentials stored in the
'CredentialCache' Object*.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Collections;

// <Snippet1>
void Display( NetworkCredential^ credential )
{
   Console::WriteLine( "\n\tUsername : {0} , Password : {1} , Domain : {2}", credential->UserName, credential->Password, credential->Domain );
}

void GetPage( String^ url, String^ userName, String^ password, String^ domainName )
{
   try
   {
      CredentialCache^ myCredentialCache = gcnew CredentialCache;

      // Dummy Credentials used here.
      myCredentialCache->Add( gcnew Uri( "http://microsoft.com/" ), "Basic", gcnew NetworkCredential( "user1","passwd1","domain1" ) );
      myCredentialCache->Add( gcnew Uri( "http://msdn.com/" ), "Basic", gcnew NetworkCredential( "user2","passwd2","domain2" ) );
      myCredentialCache->Add( gcnew Uri( url ), "Basic", gcnew NetworkCredential( userName,password,domainName ) );

      // Creates a webrequest with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      myWebRequest->Credentials = myCredentialCache;
      IEnumerator^ listCredentials = myCredentialCache->GetEnumerator();
      Console::WriteLine( "\nDisplaying credentials stored in CredentialCache: " );
      while ( listCredentials->MoveNext() )
            Display( dynamic_cast<NetworkCredential^>(listCredentials->Current) );
      Console::WriteLine( "\nNow Displaying the same using 'foreach' : " );

      // Can use foreach with CredentialCache(Since GetEnumerator function of IEnumerable* has been implemented by 'CredentialCache' class.
      IEnumerator^ myEnum = myCredentialCache->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         NetworkCredential^ credential = safe_cast<NetworkCredential^>(myEnum->Current);
         Display( credential );
      }
      WebResponse^ myWebResponse = myWebRequest->GetResponse();

      // Process response here.
      Console::WriteLine( "\nResponse Received." );
      myWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      if ( e->Response != nullptr )
            Console::WriteLine( "\r\nFailed to obtain a response. The following error occured : {0}", (dynamic_cast<HttpWebResponse^>(e->Response))->StatusDescription );
      else
            Console::WriteLine( "\r\nFailed to obtain a response. The following error occured : {0}", e->Status );
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
      Console::WriteLine( "\n CredentialCache_GetEnumerator <url> <User Name> <Password> <Domain Name>" );
      Console::WriteLine( "\n Example: CredentialCache_GetEnumerator http://www.microsoft.com  Catherine cath$ microsoft" );
   }
   else
   if ( args->Length == 4 )
   {
      GetPage( args[ 0 ], args[ 1 ], args[ 2 ], args[ 3 ] );
   }
   else
   {
      Console::WriteLine( "\n Invalid arguments." );
      return 0;
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
   return 0;
}
