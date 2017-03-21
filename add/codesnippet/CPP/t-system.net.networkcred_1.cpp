      NetworkCredential^ myCred = gcnew NetworkCredential(
         SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain );

      CredentialCache^ myCache = gcnew CredentialCache;

      myCache->Add( gcnew Uri( "www.contoso.com" ), "Basic", myCred );
      myCache->Add( gcnew Uri( "app.contoso.com" ), "Basic", myCred );

      WebRequest^ wr = WebRequest::Create( "www.contoso.com" );
      wr->Credentials = myCache;