      HashAlgorithm^ sha = gcnew SHA1CryptoServiceProvider;
      array<Byte>^ result = sha->ComputeHash( dataArray );