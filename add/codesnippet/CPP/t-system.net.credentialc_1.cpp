      CredentialCache^ myCache = gcnew CredentialCache;

      myCache->Add( gcnew Uri( "http://www.contoso.com/" ), "Basic", gcnew NetworkCredential( UserName,SecurelyStoredPassword ) );
      myCache->Add( gcnew Uri( "http://www.contoso.com/" ), "Digest", gcnew NetworkCredential( UserName,SecurelyStoredPassword,Domain ) );

      wReq->Credentials = myCache;