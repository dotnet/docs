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

