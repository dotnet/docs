   // Specify the properties for the server channel.
   System::Collections::IDictionary^ dict = gcnew System::Collections::Hashtable;
   dict[ "port" ] = 9090;
   dict[ "authenticationMode" ] = "IdentifyCallers";

   // Set up the server channel.
   TcpChannel^ serverChannel = gcnew TcpChannel( dict,nullptr,nullptr );
   ChannelServices::RegisterChannel( serverChannel );