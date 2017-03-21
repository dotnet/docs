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