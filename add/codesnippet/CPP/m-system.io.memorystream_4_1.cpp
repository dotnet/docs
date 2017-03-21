      // Read the first 20 bytes from the stream.
      byteArray = gcnew array<Byte>(memStream->Length);
      count = memStream->Read( byteArray, 0, 20 );