      Dim so As StateObject = CType(ar.AsyncState, StateObject)
      Dim s As Socket = so.workSocket
      
      ' Creates a temporary EndPoint to pass to EndReceiveFrom.
      Dim sender As New IPEndPoint(IPAddress.Any, 0)
      Dim tempRemoteEP As EndPoint = CType(sender, EndPoint)
      
      Dim read As Integer = s.EndReceiveFrom(ar, tempRemoteEP)
      
      
      If read > 0 Then
         so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read))
         s.BeginReceiveFrom(so.buffer, 0, StateObject.BUFFER_SIZE, 0, tempRemoteEP, New AsyncCallback(AddressOf Async_Send_Receive.ReceiveFrom_Callback), so)
      Else
         If so.sb.Length > 1 Then
            'All the data has been read, so displays it to the console.
            Dim strContent As String
            strContent = so.sb.ToString()
            Console.WriteLine([String].Format("Read {0} byte from socket" + "data = {1} ", strContent.Length, strContent))
         End If
         s.Close()
      End If 
   End Sub 'ReceiveFrom_Callback
   