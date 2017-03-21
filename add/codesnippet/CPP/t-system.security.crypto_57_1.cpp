      array<Byte>^ data = gcnew array<Byte>( DATA_SIZE );
      array<Byte>^ result;
      SHA1^ shaM = gcnew SHA1Managed;
      result = shaM->ComputeHash( data );