         ' Examples for CanRead, Read, and DataAvailable.
         ' Check to see if this NetworkStream is readable.
         If myNetworkStream.CanRead Then
            Dim myReadBuffer(1024) As Byte
                Dim myCompleteMessage As StringBuilder = New StringBuilder()
            Dim numberOfBytesRead As Integer = 0
            
            ' Incoming message may be larger than the buffer size.
            Do
               numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length)
                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
            Loop While myNetworkStream.DataAvailable
            
            ' Print out the received message to the console.
                Console.WriteLine(("You received the following message : " + myCompleteMessage.ToString()))
         Else
            Console.WriteLine("Sorry.  You cannot read from this NetworkStream.")
         End If
         