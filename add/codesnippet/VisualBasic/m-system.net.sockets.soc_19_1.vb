   Public Shared Sub Send_Callback(ar As IAsyncResult)

      Dim so As StateObject = CType(ar.AsyncState, StateObject)
      Dim s As Socket = so.workSocket
      
      Dim send As Integer = s.EndSend(ar)
      
      Console.WriteLine(("The size of the message sent was :" + send.ToString()))
      
      s.Close()
   End Sub 'Send_Callback