      // Create and register an IPC channel
      IpcServerChannel^ serverChannel = gcnew IpcServerChannel( L"remote" );
      ChannelServices::RegisterChannel( serverChannel );