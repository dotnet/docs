      // Examples for constructors that do not specify file permission.
      // Create the NetworkStream for communicating with the remote host.
      NetworkStream^ myNetworkStream;

      if ( networkStreamOwnsSocket )
      {
         myNetworkStream = gcnew NetworkStream( mySocket,true );
      }
      else
      {
         myNetworkStream = gcnew NetworkStream( mySocket );
      }