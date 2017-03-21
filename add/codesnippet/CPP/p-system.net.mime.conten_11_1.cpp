   static void CreateMessageWithMultipleViews( String^ server, String^ recipients )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",recipients,L"This e-mail message has multiple views.",L"This is some plain text." );
      
      // Construct the alternate body as HTML.
      String^ body = L"<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
      body = String::Concat( body, L"<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">" );
      body = String::Concat( body, L"</HEAD><BODY><DIV><FONT face=Arial color=#ff0000 size=2>this is some HTML text" );
      body = String::Concat( body, L"</FONT></DIV></BODY></HTML>" );
      
      // Add the alternate body to the message.
      AlternateView^ alternate = AlternateView::CreateAlternateViewFromString(body);
      message->AlternateViews->Add(alternate);

      // Send the message.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
      
      // Display the values in the ContentType for the attachment.
      ContentType^ c = alternate->ContentType;
      Console::WriteLine( L"Content type" );
      Console::WriteLine( c );
      Console::WriteLine( L"Boundary {0}", c->Boundary );
      Console::WriteLine( L"CharSet {0}", c->CharSet );
      Console::WriteLine( L"MediaType {0}", c->MediaType );
      Console::WriteLine( L"Name {0}", c->Name );
      Console::WriteLine( L"Parameters: {0}", c->Parameters->Count );
      IEnumerator^ myEnum = c->Parameters->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DictionaryEntry^ d = safe_cast<DictionaryEntry^>(myEnum->Current);
         Console::WriteLine( L"{0} = {1}", d->Key, d->Value );
      }

      Console::WriteLine();
      alternate->~AlternateView();
   }

