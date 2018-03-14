'<Snippet1>
' The following sample is intended to demonstrate how to use a
' TcpListener for synchronous communcation with a TCP client
' It creates a TcpListener that connects to the specified port (13000).
' Any TCP client that wants to use this TcpListener has to explicitly connect 
' to an address obtained by the combination of the server
' on which this TcpListener is running and the port 13000.
' This TcpListener simply echoes back the message sent by the client
' after translating it into uppercase. 
' Refer to the related client in the TcpClient class. 
'/


Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic
 _

Class MyTcpListener
   
   Public Shared Sub Main()
      
      Try
         ' Set the TcpListener on port 13000.
         Dim port As Int32 = 13000
         Dim server As New TcpListener(IPAddress.Any, port)
         
         ' Start listening for client requests.
         server.Start()
         
         ' Buffer for reading data
         Dim bytes(1024) As [Byte]
         Dim data As [String] = Nothing
         
         ' Enter the listening loop.
         While True
            Console.Write("Waiting for a connection... ")
            
            ' Perform a blocking call to accept requests.
            ' You could also user server.AcceptSocket() here.
            Dim client As TcpClient = server.AcceptTcpClient()
            Console.WriteLine("Connected!")
            
            data = Nothing
            
            ' Get a stream object for reading and writing
            Dim stream As NetworkStream = client.GetStream()
            
            Dim i As Int32
            
            ' Loop to receive all the data sent by the client.
            i = stream.Read(bytes, 0, bytes.Length)
            While (i <> 0) 
               ' Translate data bytes to a ASCII string.
               data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
               Console.WriteLine([String].Format("Received: {0}", data))
               
               ' Process the data sent by the client.
               data = data.ToUpper()
               
               Dim msg As [Byte]() = System.Text.Encoding.ASCII.GetBytes(data)
               
               ' Send back a response.
               stream.Write(msg, 0, msg.Length)
               Console.WriteLine([String].Format("Sent: {0}", data))
              
               i = stream.Read(bytes, 0, bytes.Length)

            End While
            
            ' Shutdown and end connection
            client.Close()
         End While
      Catch e As SocketException
         Console.WriteLine("SocketException: {0}", e)
      End Try
      
      Console.WriteLine(ControlChars.Cr + "Hit enter to continue...")
      Console.Read()
   End Sub 'Main
End Class 'MyTcpListener 
'</Snippet1>