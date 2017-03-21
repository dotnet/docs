   static void CreateMessageWithAttachment4( String^ server, String^ to )
   {
      
      // Specify the file to be attached and sent.
      // This example uses a file on a UNC share.
      String^ file = L"\\\\share3\\c$\\reports\\data.xls";
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"ReportMailer@contoso.com",to,L"Quarterly data report",L"See the attached spreadsheet." );
      
      // Create  the file attachment for this e-mail message.
      Attachment^ data = gcnew Attachment("qtr3.xls", MediaTypeNames::Application::Octet);
      
      // Add time stamp information for the file.
      ContentDisposition^ disposition = data->ContentDisposition;
      disposition->CreationDate = System::IO::File::GetCreationTime( file );
      disposition->ModificationDate = System::IO::File::GetLastWriteTime( file );
      disposition->ReadDate = System::IO::File::GetLastAccessTime( file );
      disposition->DispositionType = DispositionTypeNames::Attachment;
      
      // Add the file attachment to this e-mail message.
      message->Attachments->Add( data );
      
      //Send the message.
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Add credentials if the SMTP server requires them.
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      client->Send( message );
      
      // Display the message headers.
      array<String^>^keys = message->Headers->AllKeys;
      Console::WriteLine( L"Headers" );
      IEnumerator^ myEnum3 = keys->GetEnumerator();
      while ( myEnum3->MoveNext() )
      {
         String^ s = safe_cast<String^>(myEnum3->Current);
         Console::WriteLine( L"{0}:", s );
         Console::WriteLine( L"    {0}", message->Headers[ s ] );
      }

      data->~Attachment();
      client->~SmtpClient();
   }

