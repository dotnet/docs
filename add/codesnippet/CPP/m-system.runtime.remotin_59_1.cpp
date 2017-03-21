   // Set up a server channel.
   TcpServerChannel^ serverChannel = gcnew TcpServerChannel( 9090 );
   ChannelServices::RegisterChannel( serverChannel );