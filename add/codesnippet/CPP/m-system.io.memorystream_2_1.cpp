      // Write the second string to the stream, byte by byte.
      count = 0;
      while ( count < secondString->Length )
      {
         memStream->WriteByte( secondString[ count++ ] );
      }