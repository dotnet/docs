   SHA1CryptoServiceProvider^ SHA1alg =
      dynamic_cast<SHA1CryptoServiceProvider^>(
         CryptoConfig::CreateFromName( L"SHA1" ));