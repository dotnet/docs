   static void CreateTestMessage3()
   {
      MailAddress^ to = gcnew MailAddress( L"jane@contoso.com" );
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com" );
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the new SMTP client.";
      message->Body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      
      // Use the application or machine configuration to get the 
      // host, port, and credentials.
      SmtpClient^ client = gcnew SmtpClient;
      Console::WriteLine( L"Sending an e-mail message to {0} at {1} by using the SMTP host {2}.", to->User, to->Host, client->Host );
      client->Send( message );
   }

