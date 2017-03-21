WebProxy^ CreateProxyWithBypassList( bool bypassLocal )
{
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   return gcnew WebProxy( gcnew Uri( "http://contoso" ),
      bypassLocal,
      bypassList );
}