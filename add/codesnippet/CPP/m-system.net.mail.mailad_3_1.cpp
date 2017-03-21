   static void CreateBccTestMessage( String^ server )
   {
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com",L"Ben Miller" );
      MailAddress^ to = gcnew MailAddress( L"jane@contoso.com",L"Jane Clayton" );
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the SmtpClient class.";
      message->Body = L"Using this feature, you can send an e-mail message from an application very easily.";
      MailAddress^ bcc = gcnew MailAddress( L"manager1@contoso.com" );
      message->Bcc->Add( bcc );
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      Console::WriteLine( L"Sending an e-mail message to {0} and {1}.", to->DisplayName, message->Bcc );
      try
      { 
          client->Send( message );
      }
      catch ( Exception^ ex )
      {
          Console::WriteLine(L"Exception caught in CreateBccTestMessage(): {0}", 
                        ex->ToString() );
      }
      client->~SmtpClient();
   }

