   static void DisplayCertificateInformation( SslStream^ stream )
   {
      Console::WriteLine( L"Certificate revocation list checked: {0}", stream->CheckCertRevocationStatus );
      X509Certificate^ localCertificate = stream->LocalCertificate;
      if ( stream->LocalCertificate != nullptr )
      {
         Console::WriteLine( L"Local cert was issued to {0} and is valid from {1} until {2}.", 
             localCertificate->Subject, 
             localCertificate->GetEffectiveDateString(), 
             localCertificate->GetExpirationDateString() );
      }
      else
      {
         Console::WriteLine( L"Local certificate is null." );
      }

      X509Certificate^ remoteCertificate = stream->RemoteCertificate;
      if ( stream->RemoteCertificate != nullptr )
      {
         Console::WriteLine( L"Remote cert was issued to {0} and is valid from {1} until {2}.", 
            remoteCertificate->Subject, 
            remoteCertificate->GetEffectiveDateString(), 
            remoteCertificate->GetExpirationDateString() );
      }
      else
      {
         Console::WriteLine( L"Remote certificate is null." );
      }
   }


private:
