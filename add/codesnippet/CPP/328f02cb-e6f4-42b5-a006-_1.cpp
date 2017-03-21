	   // Create the key and set it to the Key property
	   // of the TripleDESCryptoServiceProvider object.
        cryptoDESProvider->Key = passwordDeriveBytes->CryptDeriveKey
            ("TripleDES", "SHA1", 192, cryptoDESProvider->IV);