   static void CreateMessageAttachment1( String^ server, String^ textMessage )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",L"ben@contoso.com",L"A text message for you.",L"Message: " );
      
      // Attach the message string to this e-mail message.
      Attachment^ data = gcnew Attachment( textMessage,MediaTypeNames::Text::Plain );
      ContentDisposition^ disposition = data->ContentDisposition;
      
      // Suggest a file name for the attachment.
      disposition->FileName = String::Format( L"message{0}", DateTime::Now );
      message->Attachments->Add( data );
      
      //Send the message.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
      
      // Display the values in the ContentDisposition for the attachment.
      Console::WriteLine( L"Content disposition" );
      Console::WriteLine( disposition );
      Console::WriteLine( L"File {0}", disposition->FileName );
      Console::WriteLine( L"Size {0}", disposition->Size );
      Console::WriteLine( L"Creation {0}", disposition->CreationDate );
      Console::WriteLine( L"Modification {0}", disposition->ModificationDate );
      Console::WriteLine( L"Read {0}", disposition->ReadDate );
      Console::WriteLine( L"Inline {0}", disposition->Inline );
      Console::WriteLine( L"Parameters: {0}", disposition->Parameters->Count );
      IEnumerator^ myEnum2 = disposition->Parameters->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DictionaryEntry^ d = safe_cast<DictionaryEntry^>(myEnum2->Current);
         Console::WriteLine( L"{0} = {1}", d->Key, d->Value );
      }

      data->~Attachment();
      client->~SmtpClient();
   }

