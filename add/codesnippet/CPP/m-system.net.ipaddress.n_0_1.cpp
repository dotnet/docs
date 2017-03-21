void NetworkToHostOrder_Integer( int networkByte )
{
   int hostByte;
   // Converts an integer value from network Byte order to host Byte order.
   hostByte = IPAddress::NetworkToHostOrder( networkByte );
   Console::WriteLine( "Network Byte order to Host Byte order of {0} is {1}", networkByte, hostByte );
}