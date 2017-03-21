      array<Byte>^ data = gcnew array<Byte>( DATA_SIZE );
      array<Byte>^ result;

      SHA384^ shaM = gcnew SHA384Managed;
      result = shaM->ComputeHash( data );