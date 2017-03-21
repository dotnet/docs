   static void CreateCopyMessage( String^ server )
   {
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com",L"Ben Miller" );
      MailAddress^ to = gcnew MailAddress( L"jane@contoso.com",L"Jane Clayton" );
      MailMessage^ message = gcnew MailMessage( from,to );
      
      // message.Subject = "Using the SmtpClient class.";
      message->Subject = L"Using the SmtpClient class.";
      message->Body = L"Using this feature, you can send an e-mail message from an application very easily.";
      
      // Add a carbon copy recipient.
      MailAddress^ copy = gcnew MailAddress( L"Notification_List@contoso.com" );
      message->CC->Add( copy );
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Include credentials if the server requires them.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      Console::WriteLine( L"Sending an e-mail message to {0} by using the SMTP host {1}.", to->Address, client->Host );
      client->Send( message );
      client->~SmtpClient();
   }

