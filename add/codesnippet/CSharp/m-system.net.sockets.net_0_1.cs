            // Examples for constructors that do not specify file permission.
            
            // Create the NetworkStream for communicating with the remote host.
            NetworkStream myNetworkStream;
            
            if (networkStreamOwnsSocket){
                 myNetworkStream = new NetworkStream(mySocket, true);          
            }
            else{
                 myNetworkStream = new NetworkStream(mySocket);     
            }