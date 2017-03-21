         ' Examples for CanWrite, and CanWrite  
         ' Check to see if this NetworkStream is writable.
         If myNetworkStream.CanWrite Then
            
            Dim myWriteBuffer As Byte() = Encoding.ASCII.GetBytes("Are you receiving this message?")
            myNetworkStream.Write(myWriteBuffer, 0, myWriteBuffer.Length)
         Else
            Console.WriteLine("Sorry.  You cannot write to this NetworkStream.")
         End If
         