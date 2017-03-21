// The serializeEndpoint function serializes the endpoint and returns the 
// SocketAddress containing the serialized endpoint data.
SocketAddress^ serializeEndpoint( IPEndPoint^ endpoint )
{
   // Serialize IPEndPoint details to a SocketAddress instance.
   SocketAddress^ socketAddress = endpoint->Serialize();

   // Display the serialized endpoint information.
   Console::WriteLine( "Endpoint.Serialize() : {0}", socketAddress );
   Console::WriteLine( "Socket->Family : {0}", socketAddress->Family );
   Console::WriteLine( "Socket->Size : {0}", socketAddress->Size );
   Console::WriteLine( "Press any key to continue." );
   Console::ReadLine();
   return socketAddress;
}