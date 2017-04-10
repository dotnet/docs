#using <System.dll>

using namespace System;
using namespace System::Net;

//<snippet1>
WebProxy^ CreateProxy()
{
   return gcnew WebProxy;
}
//</snippet1>        

//<snippet2>
WebProxy^ CreateProxyWithExampleAddress()
{
   return gcnew WebProxy( gcnew Uri( "http://contoso" ) );
}
//</snippet2>     

//<snippet3>
WebProxy^ CreateProxyWithExampleAddress( bool bypassLocal )
{
   return gcnew WebProxy( gcnew Uri( "http://contoso" ), bypassLocal );
}
//</snippet3>     

//<snippet4>
WebProxy^ CreateProxyWithBypassList( bool bypassLocal )
{
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   return gcnew WebProxy( gcnew Uri( "http://contoso" ),
      bypassLocal,
      bypassList );
}
//</snippet4>   

//<snippet6>
WebProxy^ CreateProxyWithHost()
{
   return gcnew WebProxy( "http://contoso" );
}
//</snippet6>     

//<snippet5>
WebProxy^ CreateProxyWithHostAndPort()
{
   return gcnew WebProxy( "http://contoso",80 );
}
//</snippet5>    

//<snippet7>
WebProxy^ CreateProxyWithHostAddress( bool bypassLocal )
{
   WebProxy^ proxy = gcnew WebProxy( "http://contoso",bypassLocal );
   Console::WriteLine( "Bypass proxy for local URIs?: {0}", 
      proxy->BypassProxyOnLocal );
   return proxy;
}
//</snippet7>      

//<snippet8>
WebProxy^ CreateProxyWithHostAndBypassList( bool bypassLocal )
{
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   return gcnew WebProxy( "http://contoso",
      bypassLocal,
      bypassList );
}
//</snippet8>   

//<snippet9>
WebProxy^ CreateProxyWithCredentials( bool bypassLocal )
{
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   return gcnew WebProxy( "http://contoso",
      bypassLocal,
      bypassList,
      CredentialCache::DefaultCredentials );
}
//</snippet9>   

//<snippet10>
void DisplayDefaultProxy()
{
   WebProxy^ proxy = WebProxy::GetDefaultProxy();

   Console::WriteLine( "Address: {0}", proxy->Address );

   Console::WriteLine( "Bypass on local: {0}", 
      proxy->BypassProxyOnLocal );
   int count = proxy->BypassList->Length;
   if ( count == 0 )
   {
      Console::WriteLine( "The bypass list is empty." );
      return;
   }
   array<String^>^ bypass = proxy->BypassList;
   Console::WriteLine( "The bypass list contents:" );

   for ( int i = 0; i < count; i++ )
   {
      Console::WriteLine( bypass[ i ] );
   }
}
//</snippet10>   

//<snippet11> 
void CheckDefaultProxyForRequest( Uri^ resource )
{
   WebProxy^ proxy = (WebProxy^)( WebProxy::GetDefaultProxy() );
   
   // See what proxy is used for resource.
   Uri^ resourceProxy = proxy->GetProxy( resource );
   
   // Test to see whether a proxy was selected.
   if ( resourceProxy == resource )
   {
      Console::WriteLine( "No proxy for {0}", resource );
   }
   else
   {
      Console::WriteLine( "Proxy for {0} is {1}", resource, 
         resourceProxy );
   }
}
//</snippet11>  

//<snippet12>
WebProxy^ CreateProxyAndCheckBypass( bool bypassLocal )
{
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   WebProxy^ proxy = gcnew WebProxy( "http://contoso",
      bypassLocal,
      bypassList );
   
   // Test the bypass list.
   if (  !proxy->IsBypassed( gcnew Uri( "http://www.Contoso.com" ) ) )
   {
      Console::WriteLine( "Bypass not working!" );
      return nullptr;
   }
   else
   {
      Console::WriteLine( "Bypass is working." );
      return proxy;
   }
}
//</snippet12>   

//<snippet13>
WebProxy^ CreateProxyWithCredentials2( bool bypassLocal )
{
   
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   return gcnew WebProxy( gcnew Uri( "http://contoso" ),
      bypassLocal,
      bypassList,
      CredentialCache::DefaultCredentials );
}
//</snippet13>   

int main()
{
   Uri^ resource = gcnew Uri( "http://www.example.com" );
   
   /*
   CreateProxy();
   CreateProxyWithExampleAddress();
   CreateProxyWithExampleAddress(true);
   CreateProxyWithBypassList(true);
   CreateProxyWithHost();
   CreateProxyWithHostAndPort();
   CreateProxyWithHostAddress(true);
   CreateProxyWithHostAndBypassList(true);
   CreateProxyWithCredentials(true);
   
   DisplayDefaultProxy();
   */
   // CreateProxyAndCheckBypass(false); 
   CreateProxyWithCredentials2( false );
}
