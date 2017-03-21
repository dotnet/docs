        ' Create a NetworkStream that owns clientSocket and then 
        ' create a BufferedStream on top of the NetworkStream.
        Dim netStream As New NetworkStream(clientSocket, True)
        Dim bufStream As New _
            BufferedStream(netStream, streamBufferSize)