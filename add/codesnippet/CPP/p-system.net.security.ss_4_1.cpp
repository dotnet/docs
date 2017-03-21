   static void DisplayStreamProperties( SslStream^ stream )
   {
      Console::WriteLine( L"Can read: {0}, write {1}", stream->CanRead, stream->CanWrite );
      Console::WriteLine( L"Can timeout: {0}", stream->CanTimeout );
   }

