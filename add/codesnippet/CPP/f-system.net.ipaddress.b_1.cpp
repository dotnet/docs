void PrintBroadcastAddress()
{
   // Get the IP Broadcast address and convert it to string.
   String^ IpAddressString = IPAddress::Broadcast->ToString();
   Console::WriteLine( "\nBroadcast IP address : {0}", IpAddressString );
}