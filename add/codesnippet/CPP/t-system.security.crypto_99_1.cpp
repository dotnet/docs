      array<Byte>^ data = gcnew array<Byte>( DATA_SIZE );
      array<Byte>^ result;

      SHA1^ sha = gcnew SHA1CryptoServiceProvider;
      // This is one implementation of the abstract class SHA1.
      result = sha->ComputeHash( data );