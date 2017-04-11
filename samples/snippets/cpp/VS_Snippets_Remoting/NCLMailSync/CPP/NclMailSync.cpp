
// NclMailSync
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Mail;
using namespace System::Net::Mime;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::IO;
using namespace System::Text;

public ref class CtorExamples
{
public:

   // <snippet1>
   static void CreateTestMessage1( String^ server, int port )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      String^ subject = L"Using the new SMTP client.";
      String^ body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      MailMessage^ message = gcnew MailMessage( from,to,subject,body );
      SmtpClient^ client = gcnew SmtpClient( server,port );
      
      // Credentials are necessary if the server requires the client 
      // to authenticate before it will send e-mail on the client's behalf.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      
      //Display the properties on the service point.
      ServicePoint^ p = client->ServicePoint;
      Console::WriteLine( L"Connection lease timeout: {0}", p->ConnectionLeaseTimeout );
      client->Send( message );
	  client->~SmtpClient();
   }


   // </snippet1>
   //<snippet2>
   static void CreateTestMessage2( String^ server )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the new SMTP client.";
      message->Body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Credentials are necessary if the server requires the client 
      // to authenticate before it will send e-mail on the client's behalf.
      client->UseDefaultCredentials = true;
      client->Send( message );
	  client->~SmtpClient();
   }


   //</snippet2>
   //<snippet3>
   static void CreateTimeoutTestMessage( String^ server )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      String^ subject = L"Using the new SMTP client.";
      String^ body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      MailMessage^ message = gcnew MailMessage( from,to,subject,body );
      SmtpClient^ client = gcnew SmtpClient( server );
      Console::WriteLine( L"Changing time out from {0} to 100.", client->Timeout );
      client->Timeout = 100;
      
      // Credentials are necessary if the server requires the client 
      // to authenticate before it will send e-mail on the client's behalf.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
   }


   //</snippet3>
   //<snippet4>
   static void CreateTestMessage3()
   {
      MailAddress^ to = gcnew MailAddress( L"jane@contoso.com" );
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com" );
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the new SMTP client.";
      message->Body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      
      // Use the application or machine configuration to get the 
      // host, port, and credentials.
      SmtpClient^ client = gcnew SmtpClient;
      Console::WriteLine( L"Sending an e-mail message to {0} at {1} by using the SMTP host {2}.", to->User, to->Host, client->Host );
      client->Send( message );
   }


   //</snippet4>
   //<snippet5>
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


   //</snippet5>
   //<snippet6>
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


   //</snippet6>
   //<snippet7>
   static void CreateTestMessage4( String^ server )
   {
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com" );
      MailAddress^ to = gcnew MailAddress( L"Jane@contoso.com" );
      MailMessage^ message = gcnew MailMessage( from,to );
      message->Subject = L"Using the SmtpClient class.";
      message->Body = L"Using this feature, you can send an e-mail message from an application very easily.";
      SmtpClient^ client = gcnew SmtpClient( server );
      Console::WriteLine( L"Sending an e-mail message to {0} by using SMTP host {1} port {2}.", to, client->Host, client->Port );
      client->Send( message );
      client->~SmtpClient();
   }


   //</snippet7>
   //<snippet8>
   static void CreateTestMessage5( String^ server )
   {
      String^ to = L"jane@contoso.com";
      String^ from = L"ben@contoso.com";
      String^ subject = L"Using the new SMTP client.";
      String^ body = L"Using this new feature, you can send an e-mail message from an application very easily.";
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( from, to, subject, body );
      client->~SmtpClient();
   }


   //</snippet8>
   //<snippet9>
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


   //</snippet9>
   //<snippet10>
   static void CreateCopyMessage( String^ server )
   {
      MailAddress^ from = gcnew MailAddress( L"ben@contoso.com",L"Ben Miller" );
      MailAddress^ to = gcnew MailAddress( L"jane@contoso.com",L"Jane Clayton" );
      MailMessage^ message = gcnew MailMessage( from,to );
      
      // message.Subject = "Using the SmtpClient class.";
      message->Subject = L"Using the SmtpClient class.";
      message->Body = L"Using this feature, you can send an e-mail message from an application very easily.";
      
      // Add a carbon copy recipient.
      MailAddress^ copy = gcnew MailAddress( L"Notification_List@contoso.com" );
      message->CC->Add( copy );
      SmtpClient^ client = gcnew SmtpClient( server );
      
      // Include credentials if the server requires them.
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      Console::WriteLine( L"Sending an e-mail message to {0} by using the SMTP host {1}.", to->Address, client->Host );
      client->Send( message );
      client->~SmtpClient();
   }


   //</snippet10>
   //<snippet11>
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


   //</snippet11>
   //<snippet12>
   static void CreateMessageInlineAttachment( String^ server, String^ textMessage )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",L"ben@contoso.com",L"An inline text message for you.",L"Message: " );
      
      // Attach the message string to this e-mail message.
      Attachment^ data = gcnew Attachment( textMessage,MediaTypeNames::Text::Plain );
      
      // Send textMessage as part of the e-mail body.
      message->Attachments->Add( data );
      ContentDisposition^ disposition = data->ContentDisposition;
      disposition->Inline = true;
      
      //Send the message.
      // Include credentials if the server requires them.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      client->Send( message );
      data->~Attachment();
      client->~SmtpClient();
   }


   //</snippet12>
   //<snippet13>
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


   //</snippet13>
   //<snippet14>
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


   //</snippet14>
   //<snippet15>
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


   //</snippet15>
   //<snippet16>
   // The following example sends a summary of a log file as the message
   // and the log as an e-mail attachment.
   static void SendNamedAndTypedErrorLog( String^ server, String^ recipientList )
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
      
      // Create a name for the log data file.
      String^ name = String::Format( L"log{0}.txt", DateTime::Now );
      
      // Create the attachment, name it, and specify the MIME type.
      Attachment^ data = gcnew Attachment( fs,name,MediaTypeNames::Text::Plain );
      
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


   //</snippet16>
   //<snippet17>
   static Attachment^ SendAttachedMessage( String^ server )
   {
      
      // Set up the sender information.
      String^ from = String::Concat( Environment::UserDomainName, L".", Environment::UserName, L"@contoso.com" );
      Console::WriteLine( L"From: {0}", from );
      
      // Have the user enter the message recipient.
      Console::Write( L"To: " );
      String^ recipient = Console::ReadLine();
      
      // Check for recipient data.
      // A real application would add error checking here for a valid e-mail 
      // address format. This example accepts any input.
      if ( recipient->Length == 0 )
            return nullptr;

      
      // Get the subject.
      Console::Write( L"Subject: " );
      String^ subject = Console::ReadLine();
      
      // Get the message content.
      Console::WriteLine( L"Enter the message. Press return on a blank line to finish:" );
      StringBuilder^ sb = gcnew StringBuilder;
      String^ line;
      while ( true )
      {
         line = Console::ReadLine();
         if ( line->Length > 0 )
         {
            
            // Store the message and the end-of-line characters.
            sb->AppendFormat( L"{0},{1}", line, Environment::NewLine );
         }
         else
                  break;
      }

      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( from,recipient );
      message->Subject = subject;
      
      // Attach the message string to this e-mail message.
      // Set the encoding to the computer's current encoding.
      Attachment^ data = gcnew Attachment( sb->ToString(),MediaTypeNames::Text::Plain);
      
      // Add the attachment to the message.
      message->Attachments->Add( data );
      
      //Send the message. Supply credentials if necessary.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = CredentialCache::DefaultNetworkCredentials;
      Console::WriteLine( L"Ready to send. Press enter to send. Type any character to quit:" );
      String^ answer = Console::ReadLine();
      if ( answer->Length == 0 )
      {
         client->Send( message );
         Console::WriteLine( L"Message sent." );
      }
      else
      {
         Console::WriteLine( L"Send canceled." );
      }

      client->~SmtpClient();
      return data;
   }


   //</snippet17>
   //<snippet18>
   static void CreateMessageWithFile( String^ server, String^ to )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"ReportMailer@contoso.com",to );
      message->Subject = L"Monthly Expense report";
      message->Body = L"Please review the attached report.";
      
      // Attach a file to this e-mail message.
      Attachment^ data = gcnew Attachment("data.xls", MediaTypeNames::Application::Octet);
      AttachmentCollection^ attachments = message->Attachments;
      attachments->Add( data );
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      client->Send( message );
      client->~SmtpClient();
   }


   //</snippet18>
   //<snippet19>
   static void DisplayFileAttachment( Attachment^ a )
   {
      Console::WriteLine( L"Content Disposition {0}", a->ContentDisposition );
      Console::WriteLine( L"Content Type {0}", a->ContentType );
      Console::WriteLine( L"Name {0}", a->Name );
   }


   //</snippet19>
   //<snippet20>
   static void DisplayStringAttachment( Attachment^ a )
   {
      Console::WriteLine( L"Content: {0}", a->ContentType );
      Console::WriteLine( L"Encoding {0}", a->TransferEncoding );
      Console::WriteLine( L"Content Disposition {0}", a->ContentDisposition->ToString() );
      Console::WriteLine( L"Content Type {0}", a->ContentType->ToString() );
   }


   //</snippet20>
   //<snippet21>
   static void DisplayStreamAttachment( Attachment^ a )
   {
      Stream^ s = a->ContentStream;
      StreamReader^ reader = gcnew StreamReader( s );
      Console::WriteLine( L"Content: {0}", reader->ReadToEnd() );
      Console::WriteLine( L"Content Type {0}", a->ContentType );
      Console::WriteLine( L"Transfer Encoding {0}", a->TransferEncoding );
      
      // Note that you cannot close the reader before the e-mail is sent. 
      // Closing the reader before sending the e-mail will close the 
      // ContentStream and cause an SmtpException.
      reader = nullptr;
   }


   //</snippet21>
   //<snippet22>
   static void CreateMessageWithAttachment2( String^ server, String^ to )
   {
      
      // Specify the file to be attached and sent.
      // This example assumes that a file named Data.xls exists in the
      // current working directory.
      String^ file = L"data.xls";
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"ReportMailer@contoso.com",to,L"Quarterly data report",L"See the attached spreadsheet." );
      
      // Create  the file attachment for this e-mail message.
      Attachment^ data = gcnew Attachment(file);
      
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
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      client->Send( message );
      data->~Attachment();
      client->~SmtpClient();
   }


   //</snippet22>
   //<snippet23>
   static void CreateMessageWithAttachment3( String^ server, String^ to )
   {
      
      // Specify the file to be attached and sent.
      // This example assumes that a file named data.xls exists in the
      // current working directory.
      String^ file = L"data.xls";
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"ReportMailer@contoso.com",to,L"Quarterly data report",L"See the attached spreadsheet." );
      
      // Create  the file attachment for this e-mail message.
      Attachment^ data = gcnew Attachment("Qtr3.xls");
      
      
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
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      
      // Notify user if an error occurs.
      try
      {
         client->Send( message );
      }
      catch ( SmtpException^ e ) 
      {
         Console::WriteLine( L"Error: {0}", e->StatusCode );
      }
      finally
      {
         data->~Attachment();
         client->~SmtpClient();
      }

   }


   //</snippet23>
   //<snippet24>
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


   //</snippet24>
   //<snippet25>
   static void CreateMessageAttachment5( String^ server, String^ textMessage )
   {
      
      // Create a message and set up the recipients.
      MailMessage^ message = gcnew MailMessage( L"jane@contoso.com",L"ben@contoso.com",L"A text message for you.",L"Message: " );
      
      // Attach the message string to this e-mail message.
      Attachment^ data = gcnew Attachment(textMessage,
                                    MediaTypeNames::Text::Plain);
      ContentDisposition^ disposition = data->ContentDisposition;
      
      // Suggest a file name for the attachment.
      disposition->FileName = String::Format( L"message{0}", DateTime::Now );
      message->Attachments->Add( data );
      
      //Send the message.
      SmtpClient^ client = gcnew SmtpClient( server );
      client->Credentials = dynamic_cast<ICredentialsByHost^>(CredentialCache::DefaultNetworkCredentials);
      client->Send( message );
      data->~Attachment();
      client->~SmtpClient();
   }


   //</snippet25>
   //<snippet26>
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


   //</snippet26>
   //<snippet27>
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


   //</snippet27>
   // silly snippets to get code coverage in exceptions!
   //<snippet28>
   static SmtpException^ GenerateDefaultSmtpException()
   {
      return gcnew SmtpException;
   }


   //</snippet28>
   //<snippet29>
   static SmtpException^ GenerateSmtpException( String^ message )
   {
      return gcnew SmtpException( message );
   }


   //</snippet29>
   //<snippet30>
   static SmtpException^ GenerateSmtpException( SmtpStatusCode status )
   {
      return gcnew SmtpException( status );
   }


   //</snippet30>
   //<snippet31>
   static SmtpException^ GenerateSmtpException( SmtpStatusCode status, String^ message )
   {
      return gcnew SmtpException( status,message );
   }


   //</snippet31>
   //<snippet32>
   static SmtpException^ GenerateSmtpException( String^ message, Exception^ innerException )
   {
      return gcnew SmtpException( message,innerException );
   }


   //</snippet32>
   static void CreateSampleDispositions()
   {
      
      //<snippet33>
      ContentDisposition^ c1 = gcnew ContentDisposition;
      Console::WriteLine( c1 );
      
      //</snippet33>
      //<snippet34>
      ContentDisposition^ c2 = gcnew ContentDisposition( L"attachment" );
      Console::WriteLine( c2 );
      
      //</snippet34>
      ContentDisposition^ c3 = gcnew ContentDisposition( L"Attachment; filename = myFile;" );
      Console::WriteLine( c3 );
   }

   static void DumpMailAddress( MailAddress^ a )
   {
      Console::WriteLine( L"Display: {0} Host: {1} User: {2} Address: {3}", a->DisplayName, a->Host, a->User, a->Address );
   }

   static void CreateSampleAddresses()
   {
      MailAddress^ a1 = gcnew MailAddress( L"Ben Miller <ben@contoso.com>" );
      Console::WriteLine( a1 );
      DumpMailAddress( a1 );
      
      // WRONG but legal: Should not include angle brackets.
      MailAddress^ a2 = gcnew MailAddress( L"<ben@contoso.com>" );
      Console::WriteLine( a2 );
      DumpMailAddress( a2 );
      MailAddress^ a3 = gcnew MailAddress( L"ben.address1@contoso.com" );
      Console::WriteLine( a3 );
      DumpMailAddress( a3 );
      
      // Use a constructor that takes an address and the display name separately.
      // Throwing a format exception
      //    MailAddress a4 = new MailAddress("tom@contoso.com", "Tom Smith");
      //    Console.WriteLine(a4.ToString());
      //    DumpMailAddress(a4);
      // WRONG: Should not include angle brackets.
      //    MailAddress a5 = new MailAddress("<tom@contoso.com   >   ", "Tom Smith");
      //   Console.WriteLine(a5.ToString());
      //    DumpMailAddress(a5);
      // WRONG but legal: Should not include display name as part of address.
      MailAddress^ a6 = gcnew MailAddress( L"Tom Smith<tom@contoso.com>",L"Bill Jones" );
      Console::WriteLine( a6 );
      DumpMailAddress( a6 );
      MailAddress^ a7 = gcnew MailAddress( L"tom@contoso.com",L"      Tom Smith          " );
      Console::WriteLine( a7 );
      DumpMailAddress( a7 );
   }

   static void DisplayContentType( ContentType^ c )
   {
      Console::WriteLine( L"Boundary {0}", c->Boundary );
      Console::WriteLine( L"Charset {0}", c->CharSet );
      Console::WriteLine( L"MediaType {0}", c->MediaType );
      Console::WriteLine( L"Name {0}", c->Name );
      Console::WriteLine( L"Parameters: {0}", c->Parameters->Count );
      IEnumerator^ myEnum4 = c->Parameters->GetEnumerator();
      while ( myEnum4->MoveNext() )
      {
         DictionaryEntry^ d = safe_cast<DictionaryEntry^>(myEnum4->Current);
         Console::WriteLine( L"{0} = {1}", d->Key, d->Value );
      }
   }

   static void CreateContentTypes()
   {
      ContentType^ c1 = gcnew ContentType;
      Console::WriteLine( L"---c1 {0}", c1 );
      DisplayContentType( c1 );
      ContentType^ c2 = gcnew ContentType( L"text/html" );
      Console::WriteLine( L"---c2 {0}", c2 );
      DisplayContentType( c2 );
      ContentType^ c3 = gcnew ContentType( L"application/x-myPrivateSubtype; name=data.xyz; charset=us-ascii" );
      Console::WriteLine( L"---c3 {0}", c3 );
      DisplayContentType( c3 );
   }


   // The first argument is the recipient.
   // The second argument is the sender.
   void NCLMailSyncRun()
   {
      
      // CreateTestMessage2(args[0]);
      //CreateMessageInlineAttachment3("smarthost", "string  textMessage");
      //CreateTestMessage3();
      //CreateTestMessage4(args[0]);
      // CreateTestMessageX(args[0]);
      //CreateMessageWithMultipleViews("smarthost","sharriso@microsoft.com");
      CreateBccTestMessage( L"sharriso1" );
      
      //CreateCopyMessage("sharriso1");
      //  CreateMessageWithMultipleRecipients("sharriso1");
      //CreateTestMessageY("sharriso1");
      //CreateMessageWithAttachment("smarthost");
      //CreateContentTypes();
      // CreateMessageWithMultipleRecipients("smarthost");
      //CreateSampleAddresses();
      // CreateMessageAttachment1("smarthost", "This is an attached message.");
      //CreateMessageInlineAttachment("sharriso1", "How cool is this?");
      //CreateMessageInlineAttachment2("smarthost", "This is an attached message.");
      //SendErrorLog("smarthost", "sharriso@microsoft.com");
      //Attachment log = SendNamedErrorLog("smarthost", "sharriso@microsoft.com");
      //SendNamedAndTypedErrorLog("smarthost", "sharriso@microsoft.com");
      //Attachment a = SendAttachedMessage("smarthost");
      //DisplayStringAttachment(a);
      //  CreateMessageWithFile("smarthost", "sharriso@microsoft.com");
      // CreateMessageWithAttachment2("smarthost", "sharriso@microsoft.com");
      //    CreateMessageWithAttachment3("xx","sharriso@microsoft.com");
      //  CreateMessageWithAttachment4("smarthost", "sharriso@microsoft.com");
      //     CreateMessageAttachment5("sharriso1", "string textMessage");
      //CreateSampleDispositions();
      RetryIfBusy("sharriso1");
   }

};

void main()
{
   CtorExamples^ ce = gcnew CtorExamples;
   ce->NCLMailSyncRun();
}

