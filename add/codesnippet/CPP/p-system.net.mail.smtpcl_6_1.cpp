   static void CreateTimeoutTestMessage( String^ server )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      String^ subject = L"Using the new SMTP client.";
      String^ body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      MailMessage^ message = gcnew MailMessage( from,to,subject,body );
      SmtpClient^ client = gcnew SmtpClient( server );
      Console::WriteLine( L"Changing time out from {0} to 100.", client->Timeout );
      client->Timeout = 100;
      
      // Credentials are necessary if the server requires the client 
      // to authenticate before it will send e-mail on the client's behalf.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
   }

