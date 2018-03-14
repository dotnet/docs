Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic
 _

Class MyTcpClient
   
   
   Overloads Public Shared Sub Main(args() As [String])
      ' Parse arguments
      Dim server As [String]
      Dim message As [String]
      If args.Length < 2 Then
         message = "This is a test!"
         If args.Length = 0 Then
            server = "localhost"
         Else
            server = args(0)
         End If
      Else
         message = args(1)
         server = args(0)
      End If
      
      ' Connect to server
      Connect(server, message)
   End Sub 'Main
   
   

   ' The following function creates a TcpClient that connects to a 
   ' TcpServer listening on the specified port (13000). 
   ' When connecting to the server it forwards a message, as specified in 
   ' the input parameter. Refer to the related TcpServer in the TcpListener class.
   
' <Snippet1>
   Shared Sub Connect(server As [String], message As [String])
      Try
         ' Create a TcpClient.
         ' Note, for this client to work you need to have a TcpServer 
         ' connected to the same address as specified by the server, port
         ' combination.
         Dim port As Int32 = 13000
         Dim client As New TcpClient(server, port)
         
         ' Translate the passed message into ASCII and store it as a Byte array.
         Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(message)
         
         ' Get a client stream for reading and writing.
         '  Stream stream = client.GetStream();
         Dim stream As NetworkStream = client.GetStream()
         
         ' Send the message to the connected TcpServer. 
         stream.Write(data, 0, data.Length)
         
         Console.WriteLine("Sent: {0}", message)
         
         ' Receive the TcpServer.response.
         ' Buffer to store the response bytes.
         data = New [Byte](256) {}
         
         ' String to store the response ASCII representation.
         Dim responseData As [String] = [String].Empty
         
         ' Read the first batch of the TcpServer response bytes.
         Dim bytes As Int32 = stream.Read(data, 0, data.Length)
         responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
         Console.WriteLine("Received: {0}", responseData)
         
         ' Close everything.
         stream.Close()
         client.Close()
      Catch e As ArgumentNullException
         Console.WriteLine("ArgumentNullException: {0}", e)
      Catch e As SocketException
         Console.WriteLine("SocketException: {0}", e)
      End Try
      
      Console.WriteLine(ControlChars.Cr + " Press Enter to continue...")
      Console.Read()
   End Sub 'Connect
' </Snippet1>

End Class 'MyTcpClient 