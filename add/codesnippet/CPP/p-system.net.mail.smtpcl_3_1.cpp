   static void CreateTestMessage2( String^ server )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the new SMTP client.";
      message->Body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Credentials are necessary if the server requires the client 
      // to authenticate before it will send e-mail on the client's behalf.
      client->UseDefaultCredentials = true;
      client->Send( message );
	  client->~SmtpClient();
   }

