   bool VerifyHash( RSAParameters rsaParams, array<Byte>^signedData, array<Byte>^signature )
   {
      RSACryptoServiceProvider^ rsaCSP = gcnew RSACryptoServiceProvider;
      SHA1Managed^ hash = gcnew SHA1Managed;
      array<Byte>^hashedData;
      rsaCSP->ImportParameters( rsaParams );
	  bool dataOK = rsaCSP->VerifyData(signedData, CryptoConfig::MapNameToOID("SHA1"), signature);
      hashedData = hash->ComputeHash( signedData );
      return rsaCSP->VerifyHash( hashedData, CryptoConfig::MapNameToOID( "SHA1" ), signature );
   }