      try
      {
         Rfc2898DeriveBytes ^ k1 = gcnew Rfc2898DeriveBytes( pwd1,salt1,myIterations );
         Rfc2898DeriveBytes ^ k2 = gcnew Rfc2898DeriveBytes( pwd1,salt1 );

         // Encrypt the data.
         TripleDES^ encAlg = TripleDES::Create();
         encAlg->Key = k1->GetBytes( 16 );
         MemoryStream^ encryptionStream = gcnew MemoryStream;
         CryptoStream^ encrypt = gcnew CryptoStream( encryptionStream,encAlg->CreateEncryptor(),CryptoStreamMode::Write );
         array<Byte>^utfD1 = (gcnew System::Text::UTF8Encoding( false ))->GetBytes( data1 );