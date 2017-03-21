      Console::Write(  "This application will timeout if Send does not return within " );
      Console::WriteLine( Encoding::ASCII->GetString( s->GetSocketOption( SocketOptionLevel::Socket, SocketOptionName::SendTimeout, 4 ) ) );
      
      // Blocks until send returns.
      int i = s->Send( msg );
      
      // Blocks until read returns.
      array<Byte>^ bytes = gcnew array<Byte>(1024);

      s->Receive( bytes );
      
      //Displays to the screen.
      Console::WriteLine( Encoding::ASCII->GetString( bytes ) );
      s->Shutdown( SocketShutdown::Both );
      Console::Write(  "If data remains to be sent, this application will stay open for " );
      Console::WriteLine( safe_cast<LingerOption^>(s->GetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Linger ))->LingerTime.ToString() );
      s->Close();