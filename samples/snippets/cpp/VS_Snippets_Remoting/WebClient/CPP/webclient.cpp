#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;
using namespace System::Collections::Specialized;

int main()
{
   //<snippet1>
   try
   {
      // Download the data to a buffer.
      WebClient^ client = gcnew WebClient;

      array<Byte>^ pageData = client->DownloadData( "http://www.contoso.com" );
      String^ pageHtml = Encoding::ASCII->GetString( pageData );
      Console::WriteLine( pageHtml );
      
      // Download the data to a file.
      client->DownloadFile( "http://www.contoso.com", "page.htm" );
      
      // Upload some form post values.
      NameValueCollection^ form = gcnew NameValueCollection;
      form->Add( "MyName", "MyValue" );
      array<Byte>^ responseData = client->UploadValues( "http://www.contoso.com/form.aspx", form );
   }
   catch ( WebException^ webEx ) 
   {
      Console::WriteLine( webEx->ToString() );
      if ( webEx->Status == WebExceptionStatus::ConnectFailure )
      {
         Console::WriteLine( "Are you behind a firewall?  If so, go through the proxy server." );
      }
   }
   //</snippet1>
}
