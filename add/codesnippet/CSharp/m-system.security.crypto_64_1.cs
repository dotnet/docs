      byte[] random = new Byte[100];

      //RNGCryptoServiceProvider is an implementation of a random number generator.
      RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
      rng.GetBytes(random); // The array is now filled with cryptographically strong random bytes.