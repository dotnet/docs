   static void CreateTestMessage4( String^ server )
   {
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com" );
      MailAddress^ to = gcnew MailAddress( L"Jane@contoso.com" );
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the SmtpClient class.";
      message->Body = L"Using this feature, you can send an e-mail message from an application very easily.";
      SmtpClient^ client = gcnew SmtpClient( server );
      Console::WriteLine( L"Sending an e-mail message to {0} by using SMTP host {1} port {2}.", to, client->Host, client->Port );
      client->Send( message );
      client->~SmtpClient();
   }

