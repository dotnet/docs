
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

 _

Public Class MyTcpListenerExample
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      System.Environment.ExitCode = Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   Overloads Public Shared Function Main(args() As String) As Integer
      If args.Length = 0
	  Console.WriteLine("Enter a selection")
	  return 0
      End If
	
      If args(0) = "endpointExample" Then
         
         '<Snippet1>
         'Creates an instance of the TcpListener class by providing a local endpoint.
         Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
         Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 11000)
         
         Try
            Dim tcpListener As New TcpListener(ipLocalEndPoint)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try
      '</Snippet1>
      Else
         If args(0) = "ipAddressExample" Then
            
            '<Snippet2>
            'Creates an instance of the TcpListener class by providing a local IP address and port number.
            Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)
            
            Try
               Dim tcpListener As New TcpListener(ipAddress, 13)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
         
         '</Snippet2>
         Else
            If args(0) = "portNumberExample" Then
               
               '<Snippet3>
               'Creates an instance of the TcpListener class by providing a local port number.  
               Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)
               Try
               	Dim tcpListener As New TcpListener(ipAddress, 13)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try
            
            '</Snippet3>
            Else

             	 Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)

               Dim tcpListener As New TcpListener(ipAddress, 13)
               
               tcpListener.Start()
               
               Console.WriteLine("Waiting for a connection....")
            
               
               Try
                  '<Snippet4>
                  ' Accepts the pending client connection and returns a socket for communciation.
                  Dim socket As Socket = tcpListener.AcceptSocket()
                  Console.WriteLine("Connection accepted.")
                  
                  Dim responseString As String = "You have successfully connected to me"
                  
                  'Forms and sends a response string to the connected client.
                  Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(responseString)
                  Dim i As Integer = socket.Send(sendBytes)
                  Console.WriteLine(("Message Sent /> : " + responseString))
                  '</Snippet4>    
                  'Any communication with the remote client using the socket can go here.
             
                  'Closes the tcpListener and the socket.
                  socket.Shutdown(SocketShutdown.Both)
                  socket.Close()
                  tcpListener.Stop()
               
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try
            End If
         End If
      End If
      Return 0
   End Function 'Main
End Class 'MyTcpListenerExample 

