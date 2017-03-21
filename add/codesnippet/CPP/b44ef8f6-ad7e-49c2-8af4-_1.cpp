void LocalPingTimeout()
{
   
   // Ping's the local machine.
   Ping ^ pingSender = gcnew Ping;
   IPAddress^ address = IPAddress::Loopback;
   
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   
   // Wait 10 seconds for a reply.
   int timeout = 10000;
   PingReply ^ reply = pingSender->Send( address, timeout, buffer);
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
   else
   {
      Console::WriteLine( reply->Status );
   }
}

