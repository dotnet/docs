         // Define a MuticastOption object specifying the multicast group
         // address and the local IPAddress.
         // The multicast group address is the same one used by the server.
         mcastOption = gcnew MulticastOption( mcastAddress,localIPAddr );
         mcastSocket->SetSocketOption( SocketOptionLevel::IP, SocketOptionName::AddMembership, mcastOption );
         