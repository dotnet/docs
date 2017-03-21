   ' Example of EndRead, DataAvailable and BeginRead.
   Public Shared Sub myReadCallBack(ar As IAsyncResult)
      
      Dim myNetworkStream As NetworkStream = CType(ar.AsyncState, NetworkStream)
      Dim myReadBuffer(1024) As Byte
      Dim myCompleteMessage As [String] = ""
      Dim numberOfBytesRead As Integer
      
      numberOfBytesRead = myNetworkStream.EndRead(ar)
      myCompleteMessage = [String].Concat(myCompleteMessage, Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
      
      ' message received may be larger than buffer size so loop through until you have it all.
      While myNetworkStream.DataAvailable
         
         myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, New AsyncCallback(AddressOf NetworkStream_ASync_Send_Receive.myReadCallBack), myNetworkStream)
      End While
      
      
      ' Print out the received message to the console.
      Console.WriteLine(("You received the following message : " + myCompleteMessage))
   End Sub 'myReadCallBack
   