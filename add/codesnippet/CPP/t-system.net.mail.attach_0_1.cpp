   static void CreateMessageWithAttachment( String^ server )
   {
      
      // Specify the file to be attached and sent.
      // This example assumes that a file named Data.xls exists in the
      // current working directory.
      String^ file = L"data.xls";
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",L"ben@contoso.com",L"Quarterly data report.",L"See the attached spreadsheet." );
      
      // Create  the file attachment for this e-mail message.
      Attachment^ data = gcnew Attachment(file, MediaTypeNames::Application::Octet);
      
      // Add time stamp information for the file.
      ContentDisposition^ disposition = data->ContentDisposition;
      disposition->CreationDate = System::IO::File::GetCreationTime( file );
      disposition->ModificationDate = System::IO::File::GetLastWriteTime( file );
      disposition->ReadDate = System::IO::File::GetLastAccessTime( file );
      
      // Add the file attachment to this e-mail message.
      message->Attachments->Add( data );
      
      //Send the message.
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Add credentials if the SMTP server requires them.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
      
      // Display the values in the ContentDisposition for the attachment.
      ContentDisposition^ cd = data->ContentDisposition;
      Console::WriteLine( L"Content disposition" );
      Console::WriteLine( cd );
      Console::WriteLine( L"File {0}", cd->FileName );
      Console::WriteLine( L"Size {0}", cd->Size );
      Console::WriteLine( L"Creation {0}", cd->CreationDate );
      Console::WriteLine( L"Modification {0}", cd->ModificationDate );
      Console::WriteLine( L"Read {0}", cd->ReadDate );
      Console::WriteLine( L"Inline {0}", cd->Inline );
      Console::WriteLine( L"Parameters: {0}", cd->Parameters->Count );
      IEnumerator^ myEnum1 = cd->Parameters->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DictionaryEntry^ d = safe_cast<DictionaryEntry^>(myEnum1->Current);
         Console::WriteLine( L"{0} = {1}", d->Key, d->Value );
      }

      data->~Attachment();
      client->~SmtpClient();
   }

