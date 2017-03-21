      array<Byte>^ random = gcnew array<Byte>(100);
      //RNGCryptoServiceProvider is an implementation of a random number generator.
      RNGCryptoServiceProvider^ rng = gcnew RNGCryptoServiceProvider;
      rng->GetNonZeroBytes( random ); // The array is now filled with cryptographically strong random bytes, and none are zero.