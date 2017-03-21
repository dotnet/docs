          ' Define a MulticastOption object specifying the multicast group 
          ' address and the local IPAddress.
          ' The multicast group address is the same as the address used by the server.
          mcastOption = New MulticastOption(mcastAddress, localIPAddr)

          mcastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mcastOption)