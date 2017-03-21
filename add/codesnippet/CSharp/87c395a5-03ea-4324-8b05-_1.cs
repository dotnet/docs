            // Examples for CanWrite, and CanWrite  
           
            // Check to see if this NetworkStream is writable.
            if (myNetworkStream.CanWrite){
               
                 byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Are you receiving this message?");
                 myNetworkStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
            }
            else{
                 Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");  
            }
