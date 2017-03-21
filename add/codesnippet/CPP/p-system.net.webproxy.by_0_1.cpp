// The following method displays the properties of the 
// specified WebProxy instance.
void DisplayProxyProperties( WebProxy^ proxy )
{
   Console::WriteLine( "Address: {0}", proxy->Address );
   Console::WriteLine( "Bypass on local: {0}", proxy->BypassProxyOnLocal );

   int count = proxy->BypassList->Length;
   if ( count == 0 )
   {
      Console::WriteLine( "The bypass list is empty." );
      return;
   }

   array<String^>^bypass = proxy->BypassList;
   Console::WriteLine( "The bypass list contents:" );
   for ( int i = 0; i < count; i++ )
   {
      Console::WriteLine( bypass[ i ] );

   }
}