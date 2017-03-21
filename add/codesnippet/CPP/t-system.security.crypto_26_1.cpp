      array<Byte>^ data = gcnew array<Byte>( DATA_SIZE );
      array<Byte>^ result;

      SHA512^ shaM = gcnew SHA512Managed;
      result = shaM->ComputeHash( data );