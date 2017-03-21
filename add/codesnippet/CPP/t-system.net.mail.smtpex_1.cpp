   static void RetryIfBusy( String^ server )
   {
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com" );
      MailAddress^ to = gcnew MailAddress( L"jane@contoso.com" );
      MailMessage^ message = gcnew MailMessage( from,to );
      
      // message.Subject = "Using the SmtpClient class.";
      message->Subject = L"Using the SmtpClient class.";
      message->Body = L"Using this feature, you can send an e-mail message from an application very easily.";
      
      // Add a carbon copy recipient.
      MailAddress^ copy = gcnew MailAddress( L"Notifications@contoso.com" );
      message->CC->Add( copy );
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Include credentials if the server requires them.
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      Console::WriteLine( L"Sending an e-mail message to {0} using the SMTP host {1}.", to->Address, client->Host );
      try
      {
         client->Send( message );
      }
      catch ( SmtpFailedRecipientsException^ ex ) 
      {
         for ( int i = 0; i < ex->InnerExceptions->Length; i++ )
         {
            SmtpStatusCode status = ex->InnerExceptions[ i ]->StatusCode;
            if ( status == SmtpStatusCode::MailboxBusy || status == SmtpStatusCode::MailboxUnavailable )
            {
               Console::WriteLine( L"Delivery failed - retrying in 5 seconds." );
               System::Threading::Thread::Sleep( 5000 );
               client->Send( message );
            }
            else
            {
               Console::WriteLine( L"Failed to deliver message to {0}", ex->InnerExceptions[ i ] );
            }

         }
      }
      catch ( Exception^ ex )
      {
          Console::WriteLine(L"Exception caught in RetryIfBusy(): {0}", 
                        ex->ToString() );
      }
      finally
      {
         client->~SmtpClient();
      }
   }

