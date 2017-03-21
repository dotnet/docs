   static void CreateMessageInlineAttachment2( String^ server, String^ textMessage )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",L"ben@contoso.com",L"A text message for you.",L"Message: " );
      
      // Attach the message string to this e-mail message.
      Attachment^ data = gcnew Attachment( textMessage );
      
      // Send textMessage as part of the e-mail body.
      message->Attachments->Add( data );
      ContentType^ content = data->ContentType;
      content->MediaType = MediaTypeNames::Text::Plain;
      
      //Send the message.
      // Include credentials if the server requires them.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
      data->~Attachment();
      client->~SmtpClient();
   }

