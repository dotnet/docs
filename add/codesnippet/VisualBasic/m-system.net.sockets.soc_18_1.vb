      Dim so As StateObject = CType(ar.AsyncState, StateObject)
      Dim s As Socket = so.workSocket
      
      Dim send As Integer = s.EndSendTo(ar)
      
      Console.WriteLine(("The size of the message sent was :" + send.ToString()))
      
      s.Close()
   End Sub 'SendTo_Callback