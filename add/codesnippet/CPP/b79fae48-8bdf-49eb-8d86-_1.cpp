      String^ dateFormat = L"{0:t}";
      String^ timeStamp = (DateTime::Now.ToString());
      CryptographicException^ cryptographicException = gcnew CryptographicException( dateFormat,timeStamp );