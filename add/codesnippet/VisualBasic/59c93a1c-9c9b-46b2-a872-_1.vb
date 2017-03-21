         ' Examples for constructors that do not specify file permission.
         ' Create the NetworkStream for communicating with the remote host.
         Dim myNetworkStream As NetworkStream
         
         If networkStreamOwnsSocket Then
            myNetworkStream = New NetworkStream(mySocket, True)
         Else
            myNetworkStream = New NetworkStream(mySocket)
         End If