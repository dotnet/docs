   // Set up a client channel.
   TcpClientChannel^ clientChannel = gcnew TcpClientChannel;
   ChannelServices::RegisterChannel( clientChannel );
   