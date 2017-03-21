   // The following example sends a summary of a log file as the message
   // and the log as an e-mail attachment.
   static void SendNamedErrorLog( String^ server, String^ recipientList )
   {
      
      // Create a message from logMailer@contoso.com to recipientList.
      MailMessage^ message = gcnew MailMessage( L"logMailer@contoso.com",recipientList );
      message->Subject = L"Error Log report";
      String^ fileName = L"log.txt";
      
      // Get the file stream for the error log.
      // Requires the System.IO namespace.
      FileStream^ fs = gcnew FileStream( fileName,FileMode::Open,FileAccess::Read );
      StreamReader^ s = gcnew StreamReader( fs );
      int errors = 0;
      while ( s->ReadLine() != nullptr )
      {
         
         // Process each line from the log file here.
         errors++;
      }

      message->Body = String::Format( L"{0} errors in log as of {1}", errors, DateTime::Now );
      
      // Close the stream reader. This also closes the file.
      s->Close();
      
      // Re-open the file at the beginning to make the attachment.
      fs = gcnew FileStream( fileName,FileMode::Open,FileAccess::Read );
      
      // Make a ContentType indicating that the log data
      // that is attached is plain text and is named.
      ContentType^ ct = gcnew ContentType;
      ct->MediaType = MediaTypeNames::Text::Plain;
      ct->Name = String::Format( L"log{0}.txt", DateTime::Now );
      
      // Create the attachment.
      Attachment^ data = gcnew Attachment( fs,ct );
      
      // Add the attachment to the message.
      message->Attachments->Add( data );
      
      // Send the message.
      // Include credentials if the server requires them.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
      data->~Attachment();
      client->~SmtpClient();
      
      // Close the log file.
      fs->Close();
      return;
   }

