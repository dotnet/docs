   static void CreateTestMessage1( String^ server, int port )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      String^ subject = L"Using the new SMTP client.";
      String^ body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      MailMessage^ message = gcnew MailMessage( from,to,subject,body );
      SmtpClient^ client = gcnew SmtpClient( server,port );
      
      // Credentials are necessary if the server requires the client 
      // to authenticate before it will send e-mail on the client's behalf.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      
      //Display the properties on the service point.
      ServicePoint^ p = client->ServicePoint;
      Console::WriteLine( L"Connection lease timeout: {0}", p->ConnectionLeaseTimeout );
      client->Send( message );
	  client->~SmtpClient();
   }

