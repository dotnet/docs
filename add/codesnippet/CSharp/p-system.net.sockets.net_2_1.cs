            // Examples for CanRead, Read, and DataAvailable.
           
            // Check to see if this NetworkStream is readable.
            if(myNetworkStream.CanRead){
                byte[] myReadBuffer = new byte[1024];
                StringBuilder myCompleteMessage = new StringBuilder();
                int numberOfBytesRead = 0;

                // Incoming message may be larger than the buffer size.
                do{
                     numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

					 myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
				 					
                }
                while(myNetworkStream.DataAvailable);

                // Print out the received message to the console.
                Console.WriteLine("You received the following message : " +
                                             myCompleteMessage);
            }
            else{
                 Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            }
