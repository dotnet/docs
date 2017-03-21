      // Read the remaining bytes, byte by byte.
      while ( count < memStream->Length )
      {
         byteArray[ count++ ] = Convert::ToByte( memStream->ReadByte() );
      }