WebProxy^ CreateProxyWithCredentials( bool bypassLocal )
{
   // Do not use the proxy server for Contoso.com URIs.
   array<String^>^ bypassList = {";*.Contoso.com"};
   return gcnew WebProxy( "http://contoso",
      bypassLocal,
      bypassList,
      CredentialCache::DefaultCredentials );
}