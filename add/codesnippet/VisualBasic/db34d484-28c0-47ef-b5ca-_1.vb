         ' Example for creating a NetworkStreams
         mySocket.Connect(myIpEndPoint)
         
         ' Create the NetworkStream for communicating with the remote host.
         Dim myNetworkStream As NetworkStream
         
         If networkStreamOwnsSocket Then
            myNetworkStream = New NetworkStream(mySocket, FileAccess.ReadWrite, True)
         Else
            myNetworkStream = New NetworkStream(mySocket, FileAccess.ReadWrite)
         End If
         