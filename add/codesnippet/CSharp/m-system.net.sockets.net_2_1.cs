// Example of EndRead, DataAvailable and BeginRead.

public static void myReadCallBack(IAsyncResult ar ){

    NetworkStream myNetworkStream = (NetworkStream)ar.AsyncState;
    byte[] myReadBuffer = new byte[1024];
    String myCompleteMessage = "";
    int numberOfBytesRead;

    numberOfBytesRead = myNetworkStream.EndRead(ar);
    myCompleteMessage = 
        String.Concat(myCompleteMessage, Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));    
    
    // message received may be larger than buffer size so loop through until you have it all.
    while(myNetworkStream.DataAvailable){
    	
        myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, 
        	                                       new AsyncCallback(NetworkStream_ASync_Send_Receive.myReadCallBack), 
        	                                       myNetworkStream);  

    }

    // Print out the received message to the console.
    Console.WriteLine("You received the following message : " +
                                myCompleteMessage);
}
