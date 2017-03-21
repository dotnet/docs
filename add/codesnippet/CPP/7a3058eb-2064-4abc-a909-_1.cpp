      SecurityElement^ securityElement = gcnew SecurityElement( L"DSASignature" );
      // Create new security elements for the four algorithms.
      securityElement->AddChild( gcnew SecurityElement(
         L"Key",L"System.Security.Cryptography.DSACryptoServiceProvider" ) );
      securityElement->AddChild( gcnew SecurityElement(
         L"Digest",L"System.Security.Cryptography.SHA1CryptoServiceProvider" ) );
      securityElement->AddChild( gcnew SecurityElement(
         L"Formatter",L"System.Security.Cryptography.DSASignatureFormatter" ) );
      securityElement->AddChild( gcnew SecurityElement(
         L"Deformatter",L"System.Security.Cryptography.DSASignatureDeformatter" ) );
      SignatureDescription^ signatureDescription =
         gcnew SignatureDescription( securityElement );