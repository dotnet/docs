

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;

//<snippet1>
int main()
{
   try
   {
      WebClient^ client = gcnew WebClient;
      client->Credentials = CredentialCache::DefaultCredentials;
      array<Byte>^pageData = client->DownloadData( "http://www.contoso.com" );
      String^ pageHtml = Encoding::ASCII->GetString( pageData );
      Console::WriteLine( pageHtml );
   }
   catch ( WebException^ webEx ) 
   {
      Console::Write( webEx );
   }

}

//</snippet1>
