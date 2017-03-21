   // Specify client channel properties.
   IDictionary^ dict = gcnew Hashtable;
   dict[ "port" ] = 9090;
   dict[ "impersonationLevel" ] = "Identify";
   dict[ "authenticationPolicy" ] = "AuthPolicy, Policy";

   // Set up a client channel.
   TcpClientChannel^ clientChannel = gcnew TcpClientChannel( dict, nullptr );
   ChannelServices::RegisterChannel( clientChannel, false );