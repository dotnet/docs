   // Create a new CipherData object using a byte array to represent encrypted data.
   array<Byte>^sampledata = gcnew array<Byte>(8);
   CipherData ^ cd = gcnew CipherData( sampledata );
   