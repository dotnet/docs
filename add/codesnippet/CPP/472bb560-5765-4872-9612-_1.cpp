   // Specify server channel properties.
   IDictionary^ dict = gcnew Hashtable;
   dict[ "port" ] = 9090;
   dict[ "authenticationMode" ] = "IdentifyCallers";

   // Set up a server channel.
   TcpServerChannel^ serverChannel = gcnew TcpServerChannel( dict, nullptr );
   ChannelServices::RegisterChannel( serverChannel, false );
