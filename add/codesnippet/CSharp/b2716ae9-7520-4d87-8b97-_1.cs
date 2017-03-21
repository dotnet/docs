            // Example of CanRead, and BeginRead.

            // Check to see if this NetworkStream is readable.
            if(myNetworkStream.CanRead){
            	
                byte[] myReadBuffer = new byte[1024];
                myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, 
                                                             new AsyncCallback(NetworkStream_ASync_Send_Receive.myReadCallBack), 
                                                             myNetworkStream);  

                allDone.WaitOne();
            }
            else{
                 Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            }
