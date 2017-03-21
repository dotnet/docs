   // The following example sends a summary of a log file as the message
   // and the log as an e-mail attachment.
   static void SendErrorLog( String^ server, String^ recipientList )
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
      
      // Make a contentType indicating that the log data
      // that is attached is plain text.
      ContentType^ ct = gcnew ContentType( MediaTypeNames::Text::Plain );
      
      // Attach the log file stream to the e-mail message.
      Attachment^ data = gcnew Attachment( fs,ct );
      ContentDisposition^ disposition = data->ContentDisposition;
      
      // Suggest a file name for the attachment.
      disposition->FileName = String::Format( L"log{0}.txt", DateTime::Now );
      
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
   }

