   ' Example of EndWrite
   Public Shared Sub myWriteCallBack(ar As IAsyncResult)
      
      Dim myNetworkStream As NetworkStream = CType(ar.AsyncState, NetworkStream)
      myNetworkStream.EndWrite(ar)
   End Sub 'myWriteCallBack
   
   