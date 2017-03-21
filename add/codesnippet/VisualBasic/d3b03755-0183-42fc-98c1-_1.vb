         ' Example of CanWrite, and BeginWrite.
         ' Check to see if this NetworkStream is writable.
         If myNetworkStream.CanWrite Then
            
            Dim myWriteBuffer As Byte() = Encoding.ASCII.GetBytes("Are you receiving this message?")
            myNetworkStream.BeginWrite(myWriteBuffer, 0, myWriteBuffer.Length, New AsyncCallback(AddressOf NetworkStream_ASync_Send_Receive.myWriteCallBack), myNetworkStream)
            allDone.WaitOne()
         Else
            Console.WriteLine("Sorry.  You cannot write to this NetworkStream.")
         End If
         