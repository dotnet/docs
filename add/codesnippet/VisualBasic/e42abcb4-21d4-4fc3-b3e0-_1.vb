   Public Shared Sub Connect_Callback(ar As IAsyncResult)
      

      allDone.Set()
      Dim s As Socket = CType(ar.AsyncState, Socket)
      s.EndConnect(ar)
      Dim so2 As New StateObject()
      so2.workSocket = s
      Dim buff As Byte() = Encoding.ASCII.GetBytes("This is a test")
      s.BeginSend(buff, 0, buff.Length, 0, New AsyncCallback(AddressOf Async_Send_Receive.Send_Callback), so2)
   End Sub 'Connect_Callback
   