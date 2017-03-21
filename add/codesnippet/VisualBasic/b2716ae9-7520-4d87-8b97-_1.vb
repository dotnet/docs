         ' Example of CanRead, and BeginRead.
         ' Check to see if this NetworkStream is readable.
         If myNetworkStream.CanRead Then
            
            Dim myReadBuffer(1024) As Byte
            myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, New AsyncCallback(AddressOf NetworkStream_ASync_Send_Receive.myReadCallBack), myNetworkStream)
            
            allDone.WaitOne()
         Else
            Console.WriteLine("Sorry.  You cannot read from this NetworkStream.")
         End If
         