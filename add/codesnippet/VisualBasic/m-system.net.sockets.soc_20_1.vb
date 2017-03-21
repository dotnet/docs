   Public Shared Sub Listen_Callback(ar As IAsyncResult)
      allDone.Set()
      Dim s As Socket = CType(ar.AsyncState, Socket)
      Dim s2 As Socket = s.EndAccept(ar)
      Dim so2 As New StateObject()
      so2.workSocket = s2
      s2.BeginReceive(so2.buffer, 0, StateObject.BUFFER_SIZE, 0, New AsyncCallback(AddressOf Async_Send_Receive.Read_Callback), so2)
   End Sub 'Listen_Callback
   