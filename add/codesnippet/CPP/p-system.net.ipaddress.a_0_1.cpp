void PrintAddress( String^ IpAddressString )
{
   // Creates an instance of the IPAddress for the specified IP String* in
   // dotted-quad notation.
   IPAddress^ hostIPAddress = IPAddress::Parse( IpAddressString );
   Console::WriteLine( "\nInteger value of IP address {0} is {1}", IpAddressString, hostIPAddress->Address );
}