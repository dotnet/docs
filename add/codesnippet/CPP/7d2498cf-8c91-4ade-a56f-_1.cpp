      SignatureDescription^ signatureDescription =
         gcnew SignatureDescription;
      signatureDescription->FormatterAlgorithm =
         L"System.Security.Cryptography.DSASignatureFormatter";
      AsymmetricSignatureFormatter^ asymmetricFormatter =
         signatureDescription->CreateFormatter( dsa );