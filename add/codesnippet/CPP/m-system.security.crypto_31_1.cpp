    // Create a new CipherData object.
    CipherData^ cipher = gcnew CipherData();
    // Assign a byte array to be the CipherValue. This is a
    // byte array representing encrypted data.
    cipher->CipherValue = gcnew array<Byte>(8);