WebProxy^ CreateProxyWithExampleAddress()
{
   return gcnew WebProxy( gcnew Uri( "http://contoso" ) );
}