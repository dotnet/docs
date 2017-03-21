      // Receive the host home page content and loop until all the data is received.
      Int32 bytes = s->Receive( RecvBytes, RecvBytes->Length, SocketFlags::None );
      strRetPage =  "Default HTML page on ";
      strRetPage->Concat( server,  ":\r\n", ASCII->GetString( RecvBytes, 0, bytes ) );
      while ( bytes > 0 )
      {
         bytes = s->Receive( RecvBytes, RecvBytes->Length, SocketFlags::None );
         strRetPage->Concat( ASCII->GetString( RecvBytes, 0, bytes ) );
      }

      