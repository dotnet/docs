WebProxy^ CreateProxyWithHostAndPort()
{
   return gcnew WebProxy( "http://contoso",80 );
}