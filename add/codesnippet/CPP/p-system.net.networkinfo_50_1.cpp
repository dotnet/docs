void ShowIcmpV6BigPacketData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( " Too Big Packet ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->PacketTooBigMessagesSent, 
      statistics->PacketTooBigMessagesReceived );
}