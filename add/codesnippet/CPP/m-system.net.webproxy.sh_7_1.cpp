WebProxy^ CreateProxyWithExampleAddress( bool bypassLocal )
{
   return gcnew WebProxy( gcnew Uri( "http://contoso" ), bypassLocal );
}