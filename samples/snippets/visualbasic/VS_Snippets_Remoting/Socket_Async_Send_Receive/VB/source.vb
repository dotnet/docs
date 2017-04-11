Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

'<Snippet11>
Public Class StateObject
   Public workSocket As Socket = Nothing
   Public const BUFFER_SIZE As Integer = 1024
   Public buffer(BUFFER_SIZE) As byte
   Public sb As New StringBuilder()
End Class 'StateObject
'</Snippet11>
 _
Public Class Async_Send_Receive
   
   Public Shared allDone As New ManualResetEvent(False)
   
   
   Public Shared Sub Connect()
'<Snippet1>
      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         
         While True
            allDone.Reset()
            
            Console.WriteLine("Establishing Connection")
  
            s.BeginConnect(lep, New AsyncCallback(AddressOf Async_Send_Receive.Connect_Callback), s)
            
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'Connect
'</Snippet1>
   
   Public Shared Sub Listen()
'<Snippet2>
      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         s.Bind(lep)
         s.Listen(1000)
         
         While True
            allDone.Reset()
            
            Console.WriteLine("Waiting for a connection...")
            s.BeginAccept(New AsyncCallback(AddressOf Async_Send_Receive.Listen_Callback), s)
            
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'Listen
'</Snippet2>
   
   Public Shared Sub SendTo()
'<Snippet3>
      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         
         While True
            allDone.Reset()
            
            Dim buff As Byte() = Encoding.ASCII.GetBytes("This is a test")
            
            Console.WriteLine("Sending Message Now..")
            s.BeginSendTo(buff, 0, buff.Length, 0, lep, New AsyncCallback(AddressOf Async_Send_Receive.SendTo_Callback), s)
            
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'SendTo
'</Snippet3>
   
   Public Shared Sub ReceiveFrom()
      
'<Snippet4>
      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      
      Dim sender As New IPEndPoint(IPAddress.Any, 0)
      Dim tempRemoteEP As EndPoint = CType(sender, EndPoint)
      s.Connect(sender)
      Try
         While True
            allDone.Reset()
            Dim so2 As New StateObject()
            so2.workSocket = s
            Console.WriteLine("Attempting to Receive data from host.contoso.com")
            
            s.BeginReceiveFrom(so2.buffer, 0, StateObject.BUFFER_SIZE, 0, tempRemoteEP, New AsyncCallback(AddressOf Async_Send_Receive.ReceiveFrom_Callback), so2)
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'ReceiveFrom
'</Snippet4>
   Public Shared Sub ReceiveFrom1()
      
'<Snippet41>
      Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
      Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)
      
      Dim s As New Socket(lep.Address.AddressFamily, SocketType.DGram, ProtocolType.Udp)
      
      Dim sender As New IPEndPoint(IPAddress.Any, 0)
      Dim tempRemoteEP As EndPoint = CType(sender, EndPoint)
      s.Connect(sender)
      Try
         While True
            allDone.Reset()
            Dim so2 As New StateObject()
            so2.workSocket = s
            Console.WriteLine("Attempting to Receive data from host.contoso.com")
            
            s.BeginReceiveFrom(so2.buffer, 0, StateObject.BUFFER_SIZE, 0, tempRemoteEP, New AsyncCallback(AddressOf Async_Send_Receive.ReceiveFrom_Callback), so2)
            allDone.WaitOne()
         End While
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'ReceiveFrom
'</Snippet41>    

'<Snippet5>
   Public Shared Sub Connect_Callback(ar As IAsyncResult)
      

      allDone.Set()
      Dim s As Socket = CType(ar.AsyncState, Socket)
      s.EndConnect(ar)
      Dim so2 As New StateObject()
      so2.workSocket = s
      Dim buff As Byte() = Encoding.ASCII.GetBytes("This is a test")
      s.BeginSend(buff, 0, buff.Length, 0, New AsyncCallback(AddressOf Async_Send_Receive.Send_Callback), so2)
   End Sub 'Connect_Callback
   
'</Snippet5>

'<Snippet6>   
   Public Shared Sub Send_Callback(ar As IAsyncResult)

      Dim so As StateObject = CType(ar.AsyncState, StateObject)
      Dim s As Socket = so.workSocket
      
      Dim send As Integer = s.EndSend(ar)
      
      Console.WriteLine(("The size of the message sent was :" + send.ToString()))
      
      s.Close()
   End Sub 'Send_Callback
'</Snippet6>	
   
'<Snippet7>
   Public Shared Sub Listen_Callback(ar As IAsyncResult)
      allDone.Set()
      Dim s As Socket = CType(ar.AsyncState, Socket)
      Dim s2 As Socket = s.EndAccept(ar)
      Dim so2 As New StateObject()
      so2.workSocket = s2
      s2.BeginReceive(so2.buffer, 0, StateObject.BUFFER_SIZE, 0, New AsyncCallback(AddressOf Async_Send_Receive.Read_Callback), so2)
   End Sub 'Listen_Callback
   
'</Snippet7>
   

'<Snippet8>
   Public Shared Sub Read_Callback(ar As IAsyncResult)
      Dim so As StateObject = CType(ar.AsyncState, StateObject)
      Dim s As Socket = so.workSocket
      
      Dim read As Integer = s.EndReceive(ar)
      
      If read > 0 Then
         so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read))
         s.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, New AsyncCallback(AddressOf Async_Send_Receive.Read_Callback), so)
      Else
         If so.sb.Length > 1 Then
            'All the data has been read, so displays it to the console
            Dim strContent As String
            strContent = so.sb.ToString()
            Console.WriteLine([String].Format("Read {0} byte from socket" + "data = {1} ", strContent.Length, strContent))
         End If
         s.Close()
      End If
   End Sub 'Read_Callback
'</Snippet8>
   
   Public Shared Sub SendTo_Callback(ar As IAsyncResult)
'<Snippet9>
      Dim so As StateObject = CType(ar.AsyncState, StateObject)
      Dim s As Socket = so.workSocket
      
      Dim send As Integer = s.EndSendTo(ar)
      
      Console.WriteLine(("The size of the message sent was :" + send.ToString()))
      
      s.Close()
   End Sub 'SendTo_Callback
'</Snippet9>
   
   Public Shared Sub ReceiveFrom_Callback(ar As IAsyncResult)
      
'<Snippet10>
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
   
'</Snippet10>
   
   Public Shared Sub Main()
   End Sub 'Main
End Class 'Async_Send_Receive 
