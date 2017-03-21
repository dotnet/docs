   static void DisplaySecurityServices( SslStream^ stream )
   {
      Console::WriteLine( L"Is authenticated: {0} as server? {1}", stream->IsAuthenticated, stream->IsServer );
      Console::WriteLine( L"IsSigned: {0}", stream->IsSigned );
      Console::WriteLine( L"Is Encrypted: {0}", stream->IsEncrypted );
   }

