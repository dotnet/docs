      SignatureDescription^ signatureDescription =
         gcnew SignatureDescription;
      signatureDescription->DeformatterAlgorithm =
         L"System.Security.Cryptography.DSASignatureDeformatter";
      AsymmetricSignatureDeformatter^ asymmetricDeformatter =
         signatureDescription->CreateDeformatter( dsa );