   static void CreateMessageInlineAttachment3( String^ server, String^ textMessage )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",L"ben@contoso.com",L"An inline text message for you.",L"Message: " );
      
      // Attach the message string to this e-mail message.
      Attachment^ data = gcnew Attachment( textMessage,MediaTypeNames::Text::Plain );
      
      // Send textMessage as part of the e-mail body.
      message->Attachments->Add( data );
      ContentDisposition^ disposition = data->ContentDisposition;
      disposition->DispositionType = DispositionTypeNames::Inline;
      
      //Send the message.
      // Include credentials if the server requires them.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      client->Send( message );
      data->~Attachment();
      client->~SmtpClient();
   }

