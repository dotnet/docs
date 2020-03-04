/*
This program demonstrates the  'Loopback' and 'Broadcast' field of 'IPAddress' class.
It prints the loopback IP address 127.0.0.1 and Broadcast IP address 255.255.255.255
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
void PrintLoopbackAddress()
{
   // Gets the IP loopback address and converts it to a string.
   String^ IpAddressString = IPAddress::Loopback->ToString();
   Console::WriteLine( "Loopback IP address : {0}", IpAddressString );
}
// </Snippet1>

// <Snippet2>
void PrintBroadcastAddress()
{
   // Get the IP Broadcast address and convert it to string.
   String^ IpAddressString = IPAddress::Broadcast->ToString();
   Console::WriteLine( "\nBroadcast IP address : {0}", IpAddressString );
}
// </Snippet2>

int main()
{
   PrintLoopbackAddress();
   PrintBroadcastAddress();
}
