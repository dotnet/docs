   static void DisplaySecurityLevel( SslStream^ stream )
   {
      Console::WriteLine( L"Cipher: {0} strength {1}", stream->CipherAlgorithm, stream->CipherStrength );
      Console::WriteLine( L"Hash: {0} strength {1}", stream->HashAlgorithm, stream->HashStrength );
      Console::WriteLine( L"Key exchange: {0} strength {1}", stream->KeyExchangeAlgorithm, stream->KeyExchangeStrength );
      Console::WriteLine( L"Protocol: {0}", stream->SslProtocol );
   }

