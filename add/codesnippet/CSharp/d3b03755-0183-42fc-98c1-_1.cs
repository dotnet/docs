           //Example of CanWrite, and BeginWrite.
           
            // Check to see if this NetworkStream is writable.
            if (myNetworkStream.CanWrite){
               
                 byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Are you receiving this message?");
                 myNetworkStream.BeginWrite(myWriteBuffer, 0, myWriteBuffer.Length, 
                                                              new AsyncCallback(NetworkStream_ASync_Send_Receive.myWriteCallBack), 
                                                              myNetworkStream);
                 allDone.WaitOne();
            }
            else{
                 Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");  
            }
           