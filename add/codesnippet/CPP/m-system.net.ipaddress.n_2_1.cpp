void NetworkToHostOrder_Long( __int64 networkByte )
{
   __int64 hostByte;
   // Converts a long value from network Byte order to host Byte order.
   hostByte = IPAddress::NetworkToHostOrder( networkByte );
   Console::WriteLine( "Network Byte order to Host Byte order of {0} is {1}", networkByte, hostByte );
}