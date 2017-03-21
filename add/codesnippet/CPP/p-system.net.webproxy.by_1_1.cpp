WebProxy^ CreateProxyWithHostAddress( bool bypassLocal )
{
   WebProxy^ proxy = gcnew WebProxy( "http://contoso",bypassLocal );
   Console::WriteLine( "Bypass proxy for local URIs?: {0}", 
      proxy->BypassProxyOnLocal );
   return proxy;
}