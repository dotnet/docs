      String^ errorMessage = (L"The current operation is not supported.");
      NullReferenceException^ nullException = gcnew NullReferenceException;
      CryptographicException^ cryptographicException = gcnew CryptographicException( errorMessage,nullException );