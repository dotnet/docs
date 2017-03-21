   if ( sp->Certificate == nullptr )
      Console::WriteLine( "Certificate = (null)" );
   else
      Console::WriteLine( "Certificate = {0}", sp->Certificate );

   if ( sp->ClientCertificate == nullptr )
      Console::WriteLine( "Client Certificate = (null)" );
   else
      Console::WriteLine( "Client Certificate = {0}", sp->ClientCertificate );

   Console::WriteLine( "ProtocolVersion = {0}", sp->ProtocolVersion->ToString() );
   Console::WriteLine( "SupportsPipelining = {0}", sp->SupportsPipelining );
   