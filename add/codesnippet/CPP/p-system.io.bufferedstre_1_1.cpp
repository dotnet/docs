      if ( bufStream->CanWrite )
      {
         Client::SendData( netStream, bufStream );
      }
      