
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class MyTcpListenerExample
   
   Public Shared Function Main() As Integer
         
      Const portNumber As Integer = 13
  
      '<Snippet1>  
      
      Try

      	 Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)
        Dim tcpListener As New TcpListener(ipAddress, portNumber)
        tcpListener.Start()
        
         ' Use the Pending method to poll the underlying socket instance for client connection requests.
         If Not tcpListener.Pending() Then
            
            Console.WriteLine("Sorry, no connection requests have arrived")
         
         Else
            
            'Accept the pending client connection and return a TcpClient object initialized for communication.
            Dim tcpClient As TcpClient = tcpListener.AcceptTcpClient()
            ' Using the RemoteEndPoint property.
            Console.Write("I am listening for connections on ")
            Console.Writeline(IPAddress.Parse(CType(tcpListener.LocalEndpoint, IPEndPoint).Address.ToString())) 
            Console.Write("on port number ")
            Console.Write(CType(tcpListener.LocalEndpoint, IPEndPoint).Port.ToString())
            
            '</Snippet1>
            'Close the tcpListener and tcpClient instances
            tcpClient.Close()
         End If 
         
         
         tcpListener.Stop()
      
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
      
      Return 0
   End Function 'Main
End Class 'MyTcpListenerExample 
